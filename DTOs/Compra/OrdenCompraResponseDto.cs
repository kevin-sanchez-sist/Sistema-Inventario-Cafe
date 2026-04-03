using ProyectoInventario.models;

public class OrdenCompraResponseDto
{
    public Guid Id { get; set; }
    public string? NombreProveedor { get; set; }
    public DateTime Fecha { get; set; }
    public EstadoOrden Estado { get; set; }
    public List<DetalleOrdenCompraResponseDto>? Items { get; set; }
    public decimal Total { get; set; }
}