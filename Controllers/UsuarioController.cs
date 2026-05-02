using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.services;

[ApiController]
[Route("api/usuarios")]
[Authorize(Roles = "Admin")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // 1. Crear usuario
    [HttpPost]
    public IActionResult Create([FromBody] CreateUsuarioDto dto)
    {
        try
        {
            _usuarioService.Add(dto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 2. Desactivar usuario
    [HttpPut("{id}/desactivar")]
    public IActionResult Desactivar([FromRoute] Guid id)
    {
        try
        {
            _usuarioService.Delete(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 3. Actualizar información de usuario
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateUsuarioDto dto)
    {
        try
        {
            _usuarioService.Update(id, dto);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 4. Listar usuarios activos
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _usuarioService.GetAll();
        return Ok(users);
    }

    // 5. Obtener usuario por id
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var user = _usuarioService.GetById(id);
            return Ok(user);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}