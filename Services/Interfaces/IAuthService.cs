using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IAuthService
    {
        TokenResponseDto Login(LoginDto dto);
    }
}