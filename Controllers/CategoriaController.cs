using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categoria")]

public class CategoriaController : ControllerBase
{
    [HttpPost]
    public IActionResult Crear([FromBody] CreateCategoriaDto dto)
    {
        return Ok("Funciona");
    }
}