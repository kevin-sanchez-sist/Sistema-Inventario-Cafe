using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;

public class ProveedorService : IProveedorService
{
    private readonly IProveedorRepository _repo;

    public ProveedorService(IProveedorRepository repo)
    {
        _repo = repo;
    }

    public void Add(CreateProveedorDto dto)
    {
        // Validación de negocio
        var existe = _repo.GetAll().Any(p => p.Nombre == dto.Nombre);
        if (existe)
            throw new InvalidOperationException("Ya existe un proveedor con ese nombre.");

        var proveedor = new Proveedor(
            dto.Nombre!,
            dto.Telefono!,
            dto.Email!,
            dto.Ciudad!
        );

        _repo.Add(proveedor);
    }

    public void Update(Guid id, UpdateProveedorDto dto)
    {
        var proveedor = _repo.GetById(id);
        if (proveedor == null)
            throw new KeyNotFoundException("Proveedor no encontrado.");

        proveedor.ActualizarContacto(dto.Telefono, dto.Email, dto.Ciudad);
        _repo.Update(proveedor);
    }

    public void Delete(Guid id)
    {
        var proveedor = _repo.GetById(id);
        if (proveedor == null)
            throw new KeyNotFoundException("Proveedor no encontrado.");

        _repo.Delete(id);
    }

    public ProveedorResponseDto GetById(Guid id)
    {
        var proveedor = _repo.GetById(id);
        if (proveedor == null)
            throw new KeyNotFoundException("Proveedor no encontrado.");

        return MapToDto(proveedor);
    }

    public List<ProveedorResponseDto> GetAll()
    {
        return _repo.GetAll()
            .Select(p => MapToDto(p))
            .ToList();
    }

    private ProveedorResponseDto MapToDto(Proveedor proveedor)
    {
        return new ProveedorResponseDto
        {
            Id = proveedor.Id,
            Nombre = proveedor.Nombre,
            Telefono = proveedor.Telefono,
            Email = proveedor.Email,
            Ciudad = proveedor.Ciudad
        };
    }
}