using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _repo;

    public InventarioService(IInventarioRepository repo)
    {
        _repo = repo;
    }

    public List<InventarioResponseDto> GetAll()
    {
        return _repo.GetAll().Select(i => MapToDto(i)).ToList();
    }

    public List<InventarioResponseDto> GetByProducto(Guid productoId)
    {
        return _repo.GetByProducto(productoId).Select(i => MapToDto(i)).ToList();
    }

    public List<InventarioResponseDto> GetByOrigen(OrigenMovimiento origen)
    {
        return _repo.GetByOrigen(origen).Select(i => MapToDto(i)).ToList();
    }

    public List<InventarioResponseDto> GetByTipo(TipoMovimiento tipo)
    {
        return _repo.GetByTipo(tipo).Select(i => MapToDto(i)).ToList();
    }

    public List<InventarioResponseDto> GetByOrdenCompra(Guid ordenCompraId)
    {
        return _repo.GetByOrdenCompra(ordenCompraId).Select(i => MapToDto(i)).ToList();
    }

    public List<InventarioResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin)
    {
        return _repo.GetByRangoFechas(inicio, fin).Select(i => MapToDto(i)).ToList();
    }

    private InventarioResponseDto MapToDto(Inventario inventario)
    {
        return new InventarioResponseDto
        {
            NombreProducto = inventario.Producto.Nombre,
            Tipo = inventario.Tipo,
            Origen = inventario.Origen,
            Cantidad = inventario.Cantidad,
            CostoUnitario = inventario.CostoUnitario,
            CostoTotal = inventario.CostoTotal,
            SaldoCantidad = inventario.SaldoCantidad,
            SaldoValor = inventario.SaldoValor,
            Fecha = inventario.Fecha,
            Motivo = inventario.Motivo
        };
    }
}