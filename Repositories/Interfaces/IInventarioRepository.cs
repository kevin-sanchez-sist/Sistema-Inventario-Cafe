using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IInventarioRepository : IRepository<Inventario>
    {
        List<Inventario> GetByProducto(Guid productoId);
        List<Inventario> GetByOrigen(OrigenMovimiento origen);
        List<Inventario> GetByTipo(TipoMovimiento tipo);
        List<Inventario> GetByOrdenCompra(Guid ordenCompraId);
        List<Inventario> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}