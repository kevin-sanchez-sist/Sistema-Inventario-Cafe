using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IInventarioService
    {
        List<InventarioResponseDto> GetAll();
        List<InventarioResponseDto> GetByProducto(Guid productoId);
        List<InventarioResponseDto> GetByOrigen(OrigenMovimiento origen);
        List<InventarioResponseDto> GetByTipo(TipoMovimiento tipo);
        List<InventarioResponseDto> GetByOrdenCompra(Guid ordenCompraId);
        List<InventarioResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin);
    }
}