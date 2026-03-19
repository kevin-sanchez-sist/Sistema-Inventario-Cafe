using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IVentaRepository
    {
        void Add(Venta venta);
        void Update(Venta venta);
        void Delete(int id);
        Venta GetById(int id);
        List<Venta> GetAll();
    }
}