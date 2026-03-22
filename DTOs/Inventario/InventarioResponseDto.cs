using ProyectoInventario.models;

public class InventarioResponseDto
{
    public string? NombreProducto {get; set;}
    public int Cantidad {get; set;}
    public DateTime Fecha {get; set;}
    public TipoMovimiento Tipo {get; set;}
    public string? Motivo {get; set;}
}