using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface ICategoriaService
    {
        void Add(CreateCategoriaDto dto);
        void Delete(Guid id);
        List<CategoriaResponseDto> GetAll();
        CategoriaDetalleResponseDto GetByIdConProductos(Guid id);
    }
}