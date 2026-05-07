using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.models;
using ProyectoInventario.services;
using System.Security.Claims;

[ApiController]
[Route("api/venta")]
[Authorize]

public class VentaController : ControllerBase
{
    private readonly IVentaService _ventaService;

    public VentaController(IVentaService ventaService)
    {
        _ventaService = ventaService;
    }

    // 1. Registrar venta
    [HttpPost]
    [Authorize(Roles = "Empleado")]
    public IActionResult Create([FromBody] CreateVentaDto dto)
    {
        try
        {
            var vendedorId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _ventaService.Add(dto, vendedorId);
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

    // 2. Cancelar venta
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Cancelar([FromRoute] Guid id)
    {
        try
        {
            _ventaService.Cancelar(id);
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

    // 3. Listar ventas
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAll()
    {
        var ventas = _ventaService.GetAll();
        return Ok(ventas);
    }

    // 4. Consultar venta por id
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var venta = _ventaService.GetById(id);
            return Ok(venta);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 5. Filtrar por estado
    [HttpGet("estado/{estado}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetByStatus([FromRoute] EstadoVenta estado)
    {
        var ventas = _ventaService.GetByStatus(estado);
        return Ok(ventas);
    }

    // 6. Filtrar por rango de fechas
    [HttpGet("fechas")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetByRangoFechas([FromQuery] DateTime inicio, [FromQuery] DateTime fin)
    {
        var ventas = _ventaService.GetByRangoFechas(inicio, fin);
        return Ok(ventas);
    }
}