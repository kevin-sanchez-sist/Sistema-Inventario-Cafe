using ProyectoInventario.models;
using ProyectoInventario.repositories;

public class InMemoryProveedorRepository : InMemoryRepository<Proveedor> , IProveedorRepository
{
    public List<Proveedor> GetByCity(string city)
    {
        var Proveedores = _data.Where(p => p.Ciudad == city).ToList();
        return Proveedores;
    }
}