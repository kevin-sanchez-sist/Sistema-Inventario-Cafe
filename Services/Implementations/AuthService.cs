using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repo;
    private readonly IConfiguration _configuration;

    public AuthService(IUsuarioRepository repo, IConfiguration configuration)
    {
        _repo = repo;
        _configuration = configuration;
    }

    public TokenResponseDto Login(LoginDto dto)
    {
        var usuario = _repo.GetByEmail(dto.Email!);
        if (usuario == null || usuario.Password != dto.Password)
            throw new UnauthorizedAccessException("Credenciales incorrectas.");
        
        var token = GenerarToken(usuario);

        return new TokenResponseDto
        {
            Token = token,
            Nombre = usuario.Nombre,
            Rol = usuario.Rol.ToString()
        };
    }

    private string GenerarToken(Usuario usuario)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );

        var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nombre),
            new Claim(ClaimTypes.Role, usuario.Rol.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: credenciales
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}