using ProyectoInventario.models;

public class UsuarioResponseDto
{
    public string? Nombre {get; set;}
    public string? Email {get; set;}
    public RolUsuario Rol {get; set;}
}