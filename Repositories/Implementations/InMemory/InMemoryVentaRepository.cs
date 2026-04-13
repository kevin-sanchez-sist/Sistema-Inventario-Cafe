using ProyectoInventario.models;
using ProyectoInventario.repositories;

public class InMemoryVentaRepository : InMemoryRepository<Venta>, IVentaRepository
{
    public List<Venta> GetByRangoFechas(DateTime inicio, DateTime fin)
    {
        return _data.Where(v => v.Fecha >= inicio && v.Fecha <= fin).ToList();
    }

    public List<Venta> GetByStatus(EstadoVenta estado)
    {
        return _data.Where(v => v.Estado == estado).ToList();
    }
}