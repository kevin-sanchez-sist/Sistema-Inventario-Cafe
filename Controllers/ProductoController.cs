using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.services;
using ProyectoInventario.models;

[ApiController]
[Route("api/productos")]
[Authorize]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    // 1. Crear Producto
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Crear([FromBody] CreateProductoDto dto)
    {
         try
        {
            _productoService.Add(dto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 2. Actualizar Producto
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Actualizar([FromBody] UpdateProductoDto dto, [FromRoute] Guid id)
    {
        try
        {
            _productoService.Update(id, dto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 3. Eliminar producto
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            _productoService.Delete(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 4. Consultar productos por Id
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var producto = _productoService.GetById(id);
            return Ok(producto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // 5. Listar Productos
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var productos = _productoService.GetAll();
            return Ok(productos);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 6. Filtrar por categoria
    [HttpGet("categoria/{CategoriaId}")]
    public IActionResult GetByCategoria([FromRoute] Guid CategoriaId)
    {
        try
        {
            var productos = _productoService.GetByCategoria(CategoriaId);
            return Ok(productos);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 7. Filtrar por disponibilidad
    [HttpGet ("disponibilidad/{estado}")]
    public IActionResult GetByDisponibilidad([FromRoute] EstadoProducto estado)
    {
        try
        {
            var productos = _productoService.GetByDisponibilidad(estado);
            return Ok(productos);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 8. Modificar precio
    [HttpPut ("{id}/precio")]
    [Authorize (Roles = "Admin")]
    public IActionResult UpdatePrice([FromRoute] Guid id, [FromBody] UpdatePriceDto dto)
    {
        try
        {
            var updateDto = new UpdateProductoDto { Precio = dto.Precio };
            _productoService.Update(id, updateDto);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 9. Consultar Productos con bajo stock
    [HttpGet("bajoStock/{stock}")]
    public IActionResult GetLowStock([FromRoute] int stock)
    {
        try
        {
            var productos = _productoService.GetBajoStock(stock);
            return Ok(productos);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}