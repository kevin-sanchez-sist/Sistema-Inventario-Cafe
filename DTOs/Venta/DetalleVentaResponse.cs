public class DetalleVentaResponseDto
{
    public Guid VentaId {get; set;}
    public DateTime FechaVenta {get; set;}
    public string? NombreProducto {get; set;}
    public int Cantidad {get; set;}
    public decimal PrecioUnitario {get; set;}
    public decimal Subtotal {get; set;}
}