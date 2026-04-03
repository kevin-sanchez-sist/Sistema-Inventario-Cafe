using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IInventarioService
    {
        List<InventarioResponseDto> GetAll();
        List<InventarioResponseDto> GetByProducto(Guid productoId);
    }
}