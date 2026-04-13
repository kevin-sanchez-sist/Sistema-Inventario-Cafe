using ProyectoInventario.models;
using ProyectoInventario.repositories;

public class InMemoryProductoRepository : InMemoryRepository<Producto>, IProductoRepository
{
    public List<Producto> GetByCategoria(Guid categoriaId)
    {
        return _data.Where(p => p.Categoria?.Id == categoriaId).ToList();
    }

    public List<Producto> GetByDisponibilidad(EstadoProducto estado)
    {
        return _data.Where(p => p.Estado == estado).ToList();
    }

    public List<Producto> GetBajoStock(int umbral)
    {
        return _data.Where(p => p.Stock <= umbral).ToList();
    }
}