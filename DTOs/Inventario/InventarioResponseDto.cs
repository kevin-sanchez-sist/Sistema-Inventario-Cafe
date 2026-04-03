using ProyectoInventario.models;

public class InventarioResponseDto
{
    public string? NombreProducto { get; set; }
    public TipoMovimiento Tipo { get; set; }
    public OrigenMovimiento Origen { get; set; }
    public int Cantidad { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal CostoTotal { get; set; }
    public int SaldoCantidad { get; set; }
    public decimal SaldoValor { get; set; }
    public DateTime Fecha { get; set; }
    public string? Motivo { get; set; }
}