using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IUsuarioService
    {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario GetById(int id);
        List<Usuario> GetAll();
    }
}