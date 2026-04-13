using ProyectoInventario.models;
using ProyectoInventario.repositories;

public class InMemoryOrdenCompraRepository : InMemoryRepository<OrdenCompra>, IOrdenCompraRepository
{
    public List<OrdenCompra> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
    {
        return _data.Where(c => c.Fecha >= fechaInicio && c.Fecha <= fechaFin).ToList();
    }

    public List<OrdenCompra> GetByStatus(EstadoOrden estado)
    {
        return _data.Where(c => c.Estado == estado).ToList();
    }
}