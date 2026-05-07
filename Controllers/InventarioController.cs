using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ProyectoInventario.models;
using ProyectoInventario.services;

[ApiController]
[Route("api/inventario")]
[Authorize]


public class InventarioController : ControllerBase
{
    private readonly IInventarioService _inventarioService;

    public InventarioController(IInventarioService inventarioService)
    {
        _inventarioService = inventarioService;
    }

    /*
    Los requisitos de la gestión de inventario del proyecto final
    1. Registrar entrada de inventario. 
    2. Registrar salida automática por venta. 
    3. Validar que no se pueda vender sin stock. 
    Estan implicitos en la capa de servicios para ventas y compras, donde cada movimiento se registra automaticamente en 
    el inventario y valida el stock.
    Eete controller estará enfocada en Consultar movimientos de inventario aplicando diferentes filtros como se implemento en
    la capa de servicios.
    */

    // 1. Consultar todos los movimientos
    [HttpGet]
    public IActionResult GetAll()
    {
        var movimientos = _inventarioService.GetAll();
        return Ok(movimientos);
    }

    // 2. Consultar todos los movimientos de un producto
    [HttpGet("producto/{productoId}")]
    public IActionResult GetByProduct([FromRoute] Guid productoId)
    {
        try
        {
            var movimientos = _inventarioService.GetByProducto(productoId);
            return Ok(movimientos);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 3. Consultar todo el inventario de entrada/salida
    [HttpGet("tipoMovimiento/{tipo}")]
    public IActionResult GetByOrigen([FromRoute] TipoMovimiento tipo)
    {
        try
        {
            var movimientos = _inventarioService.GetByTipo(tipo);
            return Ok(movimientos);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 4. Obtener los movimientos de una orden de compra especifica
    [HttpGet("OrdenCompra/{ordenId}")]
    public IActionResult GetByOrden([FromRoute] Guid ordenId)
    {
        try
        {
            var movimientos = _inventarioService.GetByOrdenCompra(ordenId);
            return Ok(movimientos);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); 
        }
    }

    //5. Obtener todos los movimientos en un rango de fechas
    [HttpGet("Desde/{inicio}/Hasta/{fin}")]
    public IActionResult GetByFechas([FromRoute] DateTime inicio, DateTime fin)
    {
        try
        {
            var movimientos = _inventarioService.GetByRangoFechas(inicio, fin);
            return Ok(movimientos);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}