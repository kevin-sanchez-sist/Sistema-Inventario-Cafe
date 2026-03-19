using ProyectoInventario.models;

namespace ProyectoInventario.repositories
{
    public interface ICategoriaRepository
    {
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        Categoria GetById(int id);
        List<Categoria> GetAll();
    }
}