using ProyectoInventario.models;

public class CreateUsuarioDto
{
    public string? Nombre {get; set;}
    public string? Email {get; set;}
    public string? Password {get; set;}
    public RolUsuario Rol {get; set;}
}