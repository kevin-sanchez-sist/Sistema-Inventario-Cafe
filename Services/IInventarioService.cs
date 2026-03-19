using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IInventarioService
    {
        void Add(Inventario movimiento);
        void Update(Inventario movimiento);
        void Delete(int id);
        Inventario GetById(int id);
        List<Inventario> GetAll();
    }
}