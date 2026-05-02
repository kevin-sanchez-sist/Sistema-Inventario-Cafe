using Microsoft.VisualBasic;
using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;
using Mapster;

public class OrdenCompraService : IOrdenCompraService
{
    private readonly IOrdenCompraRepository _repo;
    private readonly IProductoRepository _productoRepo;
    private readonly IInventarioRepository _inventarioRepo;
    private readonly IProveedorRepository _proveedorRepo;

    public OrdenCompraService(IOrdenCompraRepository repo, IProductoRepository productoRepo, IInventarioRepository inventarioRepo, IProveedorRepository proveedorRepo)
    {
        _repo = repo;
        _productoRepo = productoRepo;
        _inventarioRepo = inventarioRepo;
        _proveedorRepo = proveedorRepo;
    }

    public void Add(CreateOrdenCompraDto dto)
    {
        var proveedor = _proveedorRepo.GetById(dto.ProveedorId!.Value);
        if (proveedor == null)
            throw new KeyNotFoundException("Proveedor no encontrado");

        var orden = new OrdenCompra(proveedor);

        foreach (var item in dto.Items!)
        {
            var producto = _productoRepo.GetById(item.ProductoId!.Value);
            if (producto == null)
                throw new KeyNotFoundException($"Producto con id {item.ProductoId} no encontrado.");
            
            var detalle = new DetalleOrdenCompra(producto, item.Cantidad!.Value, item.CostoUnitario!.Value);
            orden.AgregarDetalle(detalle);
        }

        _repo.Add(orden);
    }

    public void Delete(Guid id)
    {
        var orden = _repo.GetById(id);
        if (orden == null)
            throw new KeyNotFoundException("Orden de compra no encontrada.");
        
        if (orden.Estado == EstadoOrden.Recibida)
            throw new InvalidOperationException("No se puede eliminar una orden ya recibida.");
        
        _repo.Delete(id);
    }

    public List<OrdenCompraResponseDto> GetAll()
    {
        return _repo.GetAll().Adapt<List<OrdenCompraResponseDto>>();
    }

    public OrdenCompraResponseDto GetById(Guid id)
    {
        var orden = _repo.GetById(id);
        if (orden == null)
            throw new KeyNotFoundException("Orden de compra no encontrada.");
        
        return orden.Adapt<OrdenCompraResponseDto>();
    }

    public List<OrdenCompraResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin)
    {
        return _repo.GetByRangoFechas(inicio,fin).Adapt<List<OrdenCompraResponseDto>>();
    }

    public List<OrdenCompraResponseDto> GetByStatus(EstadoOrden estado)
    {
        return _repo.GetByStatus(estado).Adapt<List<OrdenCompraResponseDto>>();
    }

    public void RecibirOrden(Guid id)
    {
        var orden = _repo.GetById(id);
        if (orden == null)
            throw new KeyNotFoundException("Orden de compra no encontrada");
        
        bool exito = orden.Recibir();
        if (!exito)
            throw new InvalidOperationException("La orden no puede recibirse porque no está en estado pendiente.");

        foreach (var detalle in orden.Detalles)
        {
            detalle.Producto.ActualizarCostoPromedio(detalle.Cantidad, detalle.CostoUnitario);
            detalle.Producto.AgregarStock(detalle.Cantidad);

            var movimiento = new Inventario(
                detalle.Producto,
                TipoMovimiento.Entrada,
                OrigenMovimiento.Compra,
                detalle.Cantidad,
                detalle.CostoUnitario,
                $"Recepción de orden de compra {orden.Id}",
                orden.Id
            );
            _inventarioRepo.Add(movimiento);

            _productoRepo.Update(detalle.Producto);
        }
        _repo.Update(orden);
    }
}