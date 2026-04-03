using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface IProductoService
    {
        void Add(CreateProductoDto producto);
        void Update(Guid id, UpdateProductoDto producto);
        void Delete(Guid id);
        ProductoResponseDto? GetById(Guid id);
        List<ProductoResponseDto> GetAll();
    }
}