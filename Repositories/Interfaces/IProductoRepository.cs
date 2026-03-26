using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IProductoRepository : IRepository<Producto>
    {
        List<Producto> GetByCategoria(Guid CategoriaId);
        List<Producto> GetByDisponibilidad(EstadoProducto Estado);
        List<Producto> GetBajoStock(int limite);
    }
}