using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        List<Proveedor> GetByCity(string city);
    }
}