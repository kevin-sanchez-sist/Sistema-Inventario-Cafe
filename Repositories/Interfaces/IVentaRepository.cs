using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IVentaRepository : IRepository<Venta>
    {
        List<Venta> GetByRangoFechas(DateTime inicio, DateTime fin);
    }
}