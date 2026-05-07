using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.models;
using ProyectoInventario.services;

[ApiController]
[Route("api/ordenCompra")]
[Authorize]

public class OrdenCompraController : ControllerBase
{
    private readonly IOrdenCompraService _ordenCompraService;

    public OrdenCompraController(IOrdenCompraService ordenCompraService)
    {
        _ordenCompraService = ordenCompraService;
    }

    // 1. Crear Orden de compra
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create([FromBody] CreateOrdenCompraDto dto)
    {
        try
        {
            _ordenCompraService.Add(dto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 2. Cancelar orden de compra
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            _ordenCompraService.Delete(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 3. Listar todas las ordenes de compra
    [HttpGet]
    public IActionResult GetAll()
    {
        var ordenes = _ordenCompraService.GetAll();
        return Ok(ordenes);
    }

    // 4. Consultar orden de compra por id
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var orden = _ordenCompraService.GetById(id);
            return Ok(orden);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 5. Recibir orden de compra
    [HttpPut("recibir/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Recibir([FromRoute] Guid id)
    {
        try
        {
            _ordenCompraService.RecibirOrden(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 6. Consultar ordenes en un rango de fechas.
    [HttpGet("fechas")]
    public IActionResult GetByRangoFechas([FromQuery] DateTime inicio, [FromQuery] DateTime fin)
    {
        var ordenes = _ordenCompraService.GetByRangoFechas(inicio, fin);
        return Ok(ordenes);
    }

    // 7. Consultar por estado de orden
    [HttpGet("estado/{estado}")]
    public IActionResult GetByStatus([FromRoute] EstadoOrden estado)
    {
        var ordenes = _ordenCompraService.GetByStatus(estado);
        return Ok(ordenes);
    }
}