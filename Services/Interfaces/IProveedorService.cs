using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IProveedorService
    {
        void Add(CreateProveedorDto proveedor);
        void Update(Guid id, UpdateProveedorDto proveedor);
        void Delete(Guid id);
        ProveedorResponseDto GetById(Guid id);
        List<ProveedorResponseDto> GetAll();
    }
}