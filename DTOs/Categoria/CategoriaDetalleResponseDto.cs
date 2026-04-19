public class CategoriaDetalleResponseDto
{
    public Guid Id { get; set; }
    public string? Nombre { get; set; }
    public List<ProductoResponseDto>? Productos { get; set; }
}