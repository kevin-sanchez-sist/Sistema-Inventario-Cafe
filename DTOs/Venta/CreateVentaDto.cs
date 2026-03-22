public class CreateVentaDto
{
    public Guid? VendedorId {get; set;}
    public List<DetalleVentaDto>? Items {get; set;}
}