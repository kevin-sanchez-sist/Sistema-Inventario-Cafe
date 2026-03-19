using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IProductoService
    {
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
        Producto GetById(int id);
        List<Producto> GetAll();
    }
}