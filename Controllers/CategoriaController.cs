using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categoria")]
[Authorize]
public class CategoriaController : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Crear([FromBody] CreateCategoriaDto dto)
    {
        return Ok("Funciona");
    }
}