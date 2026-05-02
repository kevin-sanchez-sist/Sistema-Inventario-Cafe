using ProyectoInventario.models;
using ProyectoInventario.repositories;
using ProyectoInventario.services;
using Mapster;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _repo;

    public InventarioService(IInventarioRepository repo)
    {
        _repo = repo;
    }

    public List<InventarioResponseDto> GetAll()
    {
        return _repo.GetAll().Adapt<List<InventarioResponseDto>>();
    }

    public List<InventarioResponseDto> GetByProducto(Guid productoId)
    {
        return _repo.GetByProducto(productoId).Adapt<List<InventarioResponseDto>>();
    }

    public List<InventarioResponseDto> GetByOrigen(OrigenMovimiento origen)
    {
        return _repo.GetByOrigen(origen).Adapt<List<InventarioResponseDto>>();
    }

    public List<InventarioResponseDto> GetByTipo(TipoMovimiento tipo)
    {
        return _repo.GetByTipo(tipo).Adapt<List<InventarioResponseDto>>();
    }

    public List<InventarioResponseDto> GetByOrdenCompra(Guid ordenCompraId)
    {
        return _repo.GetByOrdenCompra(ordenCompraId).Adapt<List<InventarioResponseDto>>();
    }

    public List<InventarioResponseDto> GetByRangoFechas(DateTime inicio, DateTime fin)
    {
        return _repo.GetByRangoFechas(inicio, fin).Adapt<List<InventarioResponseDto>>();
    }
}