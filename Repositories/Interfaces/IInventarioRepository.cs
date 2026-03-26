using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IInventarioRepository : IRepository<Inventario>
    {
        List<Inventario> GetByProducto(Guid productoId);
    }
}