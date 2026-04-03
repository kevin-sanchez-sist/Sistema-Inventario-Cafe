public class CreateOrdenCompraDto
{
    public Guid? ProveedorId { get; set; }
    public List<DetalleOrdenCompraDto>? Items { get; set; }
}