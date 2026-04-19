using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IVentaService
    {
        void Add(CreateVentaDto venta, Guid vendedorId);
        void Cancelar(Guid id);
        VentaResponseDto GetById(Guid id);
        List<VentaResponseDto> GetAll();
        List<VentaResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin);
        List<VentaResponseDto> GetByStatus(EstadoVenta estado);
    }
}