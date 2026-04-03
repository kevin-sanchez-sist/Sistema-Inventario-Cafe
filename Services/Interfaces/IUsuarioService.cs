using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IUsuarioService
    {
        void Add(CreateUsuarioDto usuario);
        void Update(Guid id, UpdateUsuarioDto usuario);
        void Delete(Guid id);
        UsuarioResponseDto GetById(Guid id);
        List<UsuarioResponseDto> GetAll();
    }
}