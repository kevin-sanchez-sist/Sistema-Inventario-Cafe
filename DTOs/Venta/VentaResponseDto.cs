using ProyectoInventario.models;

public class VentaResponseDto
{
    public DateTime Fecha {get; set;}
    public string? Vendedor {get; set;}
    public EstadoVenta Estado {get; set;}
    public List<DetalleVentaResponseDto>? Items {get; set;}
    public decimal Total {get; set;}
}