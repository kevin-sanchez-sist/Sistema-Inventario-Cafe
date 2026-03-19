using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario GetById(int id);
        List<Usuario> GetAll();
    }
}