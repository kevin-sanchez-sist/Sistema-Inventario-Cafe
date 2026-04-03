using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IOrdenCompraRepository : IRepository<OrdenCompra>
    {
        List<OrdenCompra> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
        List<OrdenCompra> GetByStatus(EstadoOrden estado);
    }
}