using ProyectoInventario.models;

public class CreateProductoDto
{
    public string? Nombre { get; set; }
    public decimal? Precio { get; set; }
    public decimal? CostoInicial { get; set; }
    public int? Stock { get; set; }
    public TipoProducto? Tipo { get; set; }
    public string? Sabor { get; set; }
    public string? Variante { get; set; }
    public bool? EsMolido { get; set; }
    public Guid? CategoriaId { get; set; }
}