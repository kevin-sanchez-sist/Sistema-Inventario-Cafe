using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        Proveedor? GetByCity(string city);
    }
}