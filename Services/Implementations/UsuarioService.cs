using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    public void Add(CreateUsuarioDto usuarioDto)
    {
        var existe = _repo.GetAll().Any(u => u.Email == usuarioDto.Email);
        if (existe)
            throw new InvalidOperationException("Ya existe un usuario con ese email.");
        
        var usuario = new Usuario(usuarioDto.Nombre!, usuarioDto.Email!, usuarioDto.Password!, usuarioDto.Rol);

        _repo.Add(usuario);
    }

    public void Delete(Guid id)
    {
        var usuario = _repo.GetById(id);
        if (usuario == null)
            throw new KeyNotFoundException("Usuario no encontrado.");
        
        _repo.Delete(id);
    }

    public List<UsuarioResponseDto> GetAll()
    {
        return _repo.GetAll().Select(u => MapToDto(u)).ToList();
    }

    public UsuarioResponseDto GetById(Guid id)
    {
        var usuario = _repo.GetById(id);
        if (usuario == null)
            throw new KeyNotFoundException("Usuario no encontrado.");
        
        return MapToDto(usuario);
    }

    public void Update(Guid id, UpdateUsuarioDto usuario)
    {
        var usuario1 = _repo.GetById(id);
        if (usuario1 == null)
            throw new KeyNotFoundException("Usuario no encontrado.");

        usuario1.ActualizarInformacion(usuario.Email, usuario.Password);
        _repo.Update(usuario1);
    }

    private UsuarioResponseDto MapToDto(Usuario usuario)
    {
        return new UsuarioResponseDto
        {
          Nombre = usuario.Nombre,
          Email = usuario.Email,
          Rol = usuario.Rol  
        };
    }
}