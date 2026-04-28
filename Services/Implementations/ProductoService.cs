using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repo;
    private readonly ICategoriaRepository _categoriaRepo;
    private readonly IInventarioRepository _inventarioRepo;

    public ProductoService(IProductoRepository repo, ICategoriaRepository categoriaRepo, IInventarioRepository inventarioRepo)
    {
        _repo = repo;
        _categoriaRepo = categoriaRepo;
        _inventarioRepo = inventarioRepo;
    }

    public void Add(CreateProductoDto dto)
    {
        Producto producto = dto.Tipo == TipoProducto.ProductoCafe
        ? new ProductoCafe(dto.Nombre!, dto.Precio!.Value, dto.Stock!.Value, dto.Variante!, dto.EsMolido!.Value, dto.CostoInicial!.Value)
        : new ProductoDulce(dto.Nombre!, dto.Precio!.Value, dto.Stock!.Value, dto.Sabor!, dto.CostoInicial!.Value);

        if (dto.CategoriaId.HasValue)
        {
            var categoria = _categoriaRepo.GetById(dto.CategoriaId.Value);
            if (categoria == null)
                throw new KeyNotFoundException("Categoria no encontrada.");
            
            producto.AsignarCategoria(categoria);
            categoria.AgregarProducto(producto);
        }

        _repo.Add(producto);

        // Registrar entrada inicial en Kardex
        if (dto.Stock > 0)
        {
            var movimiento = new Inventario(
                producto,
                TipoMovimiento.Entrada,
                OrigenMovimiento.AjusteManual,
                dto.Stock.Value,
                dto.CostoInicial.Value,
                "Stock inicial del producto",
                null
            );
            _inventarioRepo.Add(movimiento);
        }
    }

    public void Delete(Guid id)
    {
        var producto = _repo.GetById(id);
        if (producto == null)
            throw new KeyNotFoundException("Producto no encontrado");
        
        _repo.Delete(id);
    }

    public List<ProductoResponseDto> GetAll()
    {
        return _repo.GetAll().Select(p => MapToDto(p)).ToList();
    }

    public List<ProductoResponseDto> GetBajoStock(int umbral)
    {
        return _repo.GetBajoStock(umbral).Select(p => MapToDto(p)).ToList();
    }

    public List<ProductoResponseDto> GetByCategoria(Guid categoriaId)
    {
        return _repo.GetByCategoria(categoriaId).Select(p => MapToDto(p)).ToList();
    }

    public List<ProductoResponseDto> GetByDisponibilidad(EstadoProducto estado)
    {
        return _repo.GetByDisponibilidad(estado).Select(p => MapToDto(p)).ToList();
    }

    public ProductoResponseDto? GetById(Guid id)
    {
        var producto = _repo.GetById(id);
        if (producto == null)
            throw new KeyNotFoundException("NO se ha encontrado un producto con ese id.");

        return MapToDto(producto);
    }

    public void Update(Guid id, UpdateProductoDto dto)
    {
        var producto = _repo.GetById(id);
        if (producto == null)
            throw new KeyNotFoundException("Producto no encontrado");
        
        if (dto.Precio.HasValue)
            producto.ActualizarPrecio(dto.Precio.Value);
        
        if (dto.Estado.HasValue)
            producto.ActualizarEstado(dto.Estado.Value);
        
        if (dto.Stock.HasValue)
        {
            int diferencia = dto.Stock.Value - producto.Stock;

            if (diferencia > 0)
            {
                producto.AgregarStock(diferencia);
                var movimiento = new Inventario(
                    producto,
                    TipoMovimiento.Entrada,
                    OrigenMovimiento.AjusteManual,
                    diferencia,
                    producto.CostoPromedio,
                    "Ajuste manual de stock",
                    null
                );
                _inventarioRepo.Add(movimiento);
            }
            else if (diferencia < 0)
            {
                producto.DescontarStock(Math.Abs(diferencia));

                var movimiento = new Inventario(
                    producto,
                    TipoMovimiento.Salida,
                    OrigenMovimiento.AjusteManual,
                    Math.Abs(diferencia),
                    producto.CostoPromedio,
                    "Ajuste manual de stock",
                    null
                );
                _inventarioRepo.Add(movimiento);
            }
        }

        _repo.Update(producto);
    }

    private ProductoResponseDto MapToDto(Producto producto)
    {
        var dto = new ProductoResponseDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            CostoPromedio = producto.CostoPromedio,
            Stock = producto.Stock,
            Estado = producto.Estado,
            CategoriaNombre = producto.Categoria?.Nombre
        };

        if (producto is ProductoCafe cafe)
        {
            dto.Tipo = TipoProducto.ProductoCafe;
            dto.Variante = cafe.Variante;
            dto.EsMolido = cafe.EsMolido;
        }
        else if (producto is ProductoDulce dulce)
        {
            dto.Tipo = TipoProducto.ProductoDulce;
            dto.Sabor = dulce.Sabor;
        }


        return dto;
    }
}