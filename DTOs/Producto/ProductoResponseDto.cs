using ProyectoInventario.models;

public class ProductoResponseDto
{
    public Guid Id { get; set; }
    public string? Nombre { get; set; }
    public decimal? Precio { get; set; }
    public decimal CostoPromedio { get; set; }
    public int? Stock { get; set; }
    public EstadoProducto? Estado { get; set; }
    public TipoProducto? Tipo { get; set; }
    public string? Sabor { get; set; }
    public string? Variante { get; set; }
    public bool? EsMolido { get; set; }
    public string? CategoriaNombre { get; set; }
}