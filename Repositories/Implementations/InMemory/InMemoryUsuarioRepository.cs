using ProyectoInventario.models;
using ProyectoInventario.repositories;

public class InMemoryUsuarioRepository : InMemoryRepository<Usuario>, IUsuarioRepository
{
    public Usuario? GetByEmail(string email)
    {
        return _data.FirstOrDefault(u => u.Email == email);
    }
}