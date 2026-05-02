using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;
using Mapster;

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

        if (!usuario.Activo)
            throw new InvalidOperationException("El usuario ya está desactivado.");

        usuario.Desactivar();
        _repo.Update(usuario);
    }

    public List<UsuarioResponseDto> GetAll() =>
        _repo.GetAll().Where(u => u.Activo).Adapt<List<UsuarioResponseDto>>();

    public UsuarioResponseDto GetById(Guid id)
    {
        var usuario = _repo.GetById(id);
        if (usuario == null)
            throw new KeyNotFoundException("Usuario no encontrado.");
        
        return usuario.Adapt<UsuarioResponseDto>();
    }

    public void Update(Guid id, UpdateUsuarioDto usuario)
    {
        var usuario1 = _repo.GetById(id);
        if (usuario1 == null)
            throw new KeyNotFoundException("Usuario no encontrado.");

        usuario1.ActualizarInformacion(usuario.Email, usuario.Password);
        _repo.Update(usuario1);
    }
}