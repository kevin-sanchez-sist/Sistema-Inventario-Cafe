using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IVentaService
    {
        void Add(Venta venta);
        void Update(Venta venta);
        void Delete(int id);
        Venta GetById(int id);
        List<Venta> GetAll();
    }
}