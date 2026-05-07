using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.services;

[ApiController]
[Route("api/proveedor")]
[Authorize]

public class ProveedorController : ControllerBase
{
    private readonly IProveedorService _proveedorService;

    public ProveedorController(IProveedorService proveedorService)
    {
        _proveedorService = proveedorService;
    }

    // 1. Crear proveedor
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create([FromBody] CreateProveedorDto dto)
    {
        try
        {
            _proveedorService.Add(dto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 2. Actualizar proveedor
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateProveedorDto dto)
    {
        try
        {
            _proveedorService.Update(id, dto);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 3. Eliminar proveedor
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            _proveedorService.Delete(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 4. Listar proveedores
    [HttpGet]
    public IActionResult GetAll()
    {
        var proveedores = _proveedorService.GetAll();
        return Ok(proveedores);
    }

    // 5. Consultar proveedor por id
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var proveedor = _proveedorService.GetById(id);
            return Ok(proveedor);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}