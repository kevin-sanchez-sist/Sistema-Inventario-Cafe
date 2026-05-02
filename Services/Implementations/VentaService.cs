using Mapster;
using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _repo;
    private readonly IProductoRepository _productoRepo;
    private readonly IInventarioRepository _inventarioRepo;
    private readonly IUsuarioRepository _usuarioRepo;

    public VentaService(IVentaRepository repo, IProductoRepository productoRepo, IInventarioRepository inventarioRepo, IUsuarioRepository usuarioRepo)
    {
        _repo = repo;
        _productoRepo = productoRepo;
        _inventarioRepo = inventarioRepo;
        _usuarioRepo = usuarioRepo;
    }

    public void Add(CreateVentaDto dto, Guid vendedorId)
    {
        var vendedor = _usuarioRepo.GetById(vendedorId);
        if (vendedor == null)
            throw new KeyNotFoundException("Vendedor no encontrado.");

        var venta = new Venta(vendedor);

        foreach (var item in dto.Items!)
        {
            var producto = _productoRepo.GetById(item.ProductoId!.Value);
            if (producto == null)
                throw new KeyNotFoundException($"Producto con id {item.ProductoId} no encontrado");

            bool exito = producto.DescontarStock(item.Cantidad!.Value);
            if (!exito)
                throw new InvalidOperationException($"Stock insuficiente para el producto {producto.Nombre}");

            var detalleVenta = new DetalleVenta(producto, venta, item.Cantidad!.Value);
            venta.AgregarDetalle(detalleVenta);

            var movimiento = new Inventario(
                producto,
                TipoMovimiento.Salida,
                OrigenMovimiento.Venta,
                item.Cantidad.Value,
                producto.CostoPromedio,
                $"Registro de venta {venta.Id}"
            );
            _inventarioRepo.Add(movimiento);
            _productoRepo.Update(producto);
        }

        venta.Completar();
        _repo.Add(venta);
    }

    public List<VentaResponseDto> GetAll() =>
        _repo.GetAll().Adapt<List<VentaResponseDto>>();

    public VentaResponseDto GetById(Guid id)
    {
        var venta = _repo.GetById(id);
        if (venta == null)
            throw new KeyNotFoundException("No se encontró una venta con ese id.");
        return venta.Adapt<VentaResponseDto>();
    }

    public List<VentaResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin) =>
        _repo.GetByRangoFechas(inicio, fin).Adapt<List<VentaResponseDto>>();

    public List<VentaResponseDto> GetByStatus(EstadoVenta estado) =>
        _repo.GetByStatus(estado).Adapt<List<VentaResponseDto>>();

    public void Cancelar(Guid id)
    {
        var venta = _repo.GetById(id);
        if (venta == null)
            throw new KeyNotFoundException("Venta no encontrada.");

        if (venta.Estado == EstadoVenta.Cancelada)
            throw new InvalidOperationException("La venta ya está cancelada.");

        foreach (var detalle in venta.Detalles)
        {
            detalle.Producto.AgregarStock(detalle.Cantidad);

            var movimiento = new Inventario(
                detalle.Producto,
                TipoMovimiento.Entrada,
                OrigenMovimiento.AjusteManual,
                detalle.Cantidad,
                detalle.Producto.CostoPromedio,
                $"Devolución por cancelación de venta {venta.Id}"
            );
            _inventarioRepo.Add(movimiento);
            _productoRepo.Update(detalle.Producto);
        }

        venta.Cancelar();
        _repo.Update(venta);
    }
}