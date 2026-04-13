using ProyectoInventario.models;
using ProyectoInventario.repositories;

public class InMemoryInventarioRepository : InMemoryRepository<Inventario>, IInventarioRepository
{
    public List<Inventario> GetByProducto(Guid productoId)
    {
        return _data.Where(i => i.Producto.Id == productoId).ToList();
    }

    public List<Inventario> GetByOrigen(OrigenMovimiento origen)
    {
        return _data.Where(i => i.Origen == origen).ToList();
    }

    public List<Inventario> GetByTipo(TipoMovimiento tipo)
    {
        return _data.Where(i => i.Tipo == tipo).ToList();
    }

    public List<Inventario> GetByOrdenCompra(Guid ordenCompraId)
    {
        return _data.Where(i => i.OrdenCompraId == ordenCompraId).ToList();
    }

    public List<Inventario> GetByRangoFechas(DateTime inicio, DateTime fin)
    {
        return _data.Where(i => i.Fecha >= inicio && i.Fecha <= fin).ToList();
    }
}