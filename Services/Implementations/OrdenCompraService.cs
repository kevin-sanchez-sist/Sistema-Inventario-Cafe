using Microsoft.VisualBasic;
using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

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
        return _repo.GetAll().Select(o => MapToDto(o)).ToList();
    }

    public OrdenCompraResponseDto GetById(Guid id)
    {
        var orden = _repo.GetById(id);
        if (orden == null)
            throw new KeyNotFoundException("Orden de compra no encontrada.");
        
        return MapToDto(orden);
    }

    public List<OrdenCompraResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin)
    {
        return _repo.GetByRangoFechas(inicio,fin).Select(o => MapToDto(o)).ToList();
    }

    public List<OrdenCompraResponseDto> GetByStatus(EstadoOrden estado)
    {
        return _repo.GetByStatus(estado).Select(o => MapToDto(o)).ToList();
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

    private OrdenCompraResponseDto MapToDto(OrdenCompra orden)
    {
        return new OrdenCompraResponseDto
        {
            Id =orden.Id,
            NombreProveedor = orden.Proveedor.Nombre,
            Fecha = orden.Fecha,
            Estado = orden.Estado,
            Total = orden.CalcularTotal(),
            Items = orden.Detalles.Select(d => new DetalleOrdenCompraResponseDto
            {
                NombreProducto = d.Producto.Nombre,
                Cantidad = d.Cantidad,
                CostoUnitario = d.CostoUnitario,
                Subtotal = d.CostoUnitario * d.Cantidad

            }).ToList()
        };
    }
}