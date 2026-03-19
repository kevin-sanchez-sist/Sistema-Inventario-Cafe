using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IProductoRepository
    {
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
        Producto GetById(int id);
        List<Producto> GetAll();
    }
}