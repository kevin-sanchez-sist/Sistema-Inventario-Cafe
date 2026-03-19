using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IInventarioRepository
    {
        void Add(Inventario movimiento);
        void Update(Inventario movimiento);
        void Delete(int id);
        Inventario GetById(int id);
        List<Inventario> GetAll();
    }
}