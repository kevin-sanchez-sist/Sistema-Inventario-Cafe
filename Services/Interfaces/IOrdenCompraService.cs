using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IOrdenCompraService
    {
        void Add(CreateOrdenCompraDto orden);
        void Delete(Guid id);
        void RecibirOrden(Guid id);
        OrdenCompraResponseDto GetById(Guid id);
        List<OrdenCompraResponseDto> GetAll();
        List<OrdenCompraResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin);
        
    }
}