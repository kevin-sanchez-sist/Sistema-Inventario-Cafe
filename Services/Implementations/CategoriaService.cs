using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repo;

    public CategoriaService(ICategoriaRepository repo)
    {
        _repo = repo;
    }

    //Crear una nueva categoria
    public void Add(CreateCategoriaDto categoriaDto)
    {
        //Validación de que la categoria no exista
        var existe = _repo.GetAll().Any(C => C.Nombre == categoriaDto.Nombre);
        if (existe)
            throw new InvalidOperationException("Ya existe una categoria con ese nombre.");

        var categoria = new Categoria(categoriaDto.Nombre!);

        _repo.Add(categoria);
    }

    public void Delete(Guid id)
    {
        var categoria = _repo.GetById(id);
        if (categoria == null)
            throw new KeyNotFoundException("Categoria no encontrada.");

        _repo.Delete(id);
    }

    public List<CategoriaResponseDto> GetAll()
    {
        return _repo.GetAll().Select(c => MapToDto(c)).ToList();
    }

    public CategoriaDetalleResponseDto GetByIdConProductos(Guid id)
    {
        var categoria = _repo.GetById(id);
        if (categoria == null)
            throw new KeyNotFoundException("Categoría no encontrada.");
        
        var productos = categoria.Productos.Select( p =>
        {
            var productoDto = new ProductoResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                CostoPromedio = p.CostoPromedio,
                Stock = p.Stock,
                Estado = p.Estado,
                CategoriaNombre = categoria.Nombre
            };

            if (p is ProductoCafe cafe)
            {
                productoDto.Tipo = TipoProducto.ProductoCafe;
                productoDto.Variante = cafe.Variante;
                productoDto.EsMolido = cafe.EsMolido;
            }
            else if (p is ProductoDulce dulce)
            {
                productoDto.Tipo = TipoProducto.ProductoDulce;
                productoDto.Sabor = dulce.Sabor;
            }

            return productoDto;
        }).ToList();
        
        return new CategoriaDetalleResponseDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Productos = productos
        };
    }

    private CategoriaResponseDto MapToDto(Categoria categoria)
    {
        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            ProductosActivos = categoria.ContarProductosActivos()
        };
    }
}