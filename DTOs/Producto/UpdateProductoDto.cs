using ProyectoInventario.models;

public class UpdateProductoDto
{
    public decimal? Precio {get; set;}
    public int? Stock {get; set;}
    public EstadoProducto? Estado {get; set;}
    public Guid? CategoriaId{get;set;}
}