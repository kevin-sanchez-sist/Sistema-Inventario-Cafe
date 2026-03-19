using ProyectoInventario.models;

namespace ProyectoInventario.services
{
    public interface ICategoriaService
    {
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        Categoria GetById(int id);
        List<Categoria> GetAll();
    }
}