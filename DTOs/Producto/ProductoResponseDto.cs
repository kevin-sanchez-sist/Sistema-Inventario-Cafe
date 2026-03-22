using ProyectoInventario.models;

public class ProductoResponseDto
{
    public string? Nombre {get; set;}
    public decimal? Precio {get; set;}
    public int? Stock {get; set;}
    public EstadoProducto? Estado {get; set;}
    public TipoProducto? Tipo {get; set;}
    public string? Sabor {get; set;} //solo aplica para productos dulces}}
    public string? Variante {get; set;} //solo aplica a derivados del cafe
    public bool? EsMolido{get; set;} //solo aplica a derivados del cafe
    public int? CategoriaId{get; set;} 
}