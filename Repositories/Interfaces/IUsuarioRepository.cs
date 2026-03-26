using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario? GetByEmail(string email);
    }
}