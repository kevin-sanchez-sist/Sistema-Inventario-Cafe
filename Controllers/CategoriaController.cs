using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.services;

[ApiController]
[Route("api/categoria")]
[Authorize]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {  
        _categoriaService = categoriaService;
    }

    // 1. Crear categoria
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Crear([FromBody] CreateCategoriaDto dto)
    {
        try
        {
            _categoriaService.Add(dto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 2. Listar Categorias
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var categorias = _categoriaService.GetAll();
            return Ok(categorias);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 3. Eliminar Categoria 
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            _categoriaService.Delete(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 4. Asociar productos a categorias
    [HttpPost("{categoriaId}/producto/{productoId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Asociar([FromRoute] Guid categoriaId, [FromRoute] Guid productoId)
    {
        try
        {
            _categoriaService.AsociarProducto(categoriaId, productoId);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    // Extra. Consultar categoria por Id con productos
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var categoria = _categoriaService.GetByIdConProductos(id);
            return Ok(categoria);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }



}