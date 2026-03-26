namespace ProyectoInventario.repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T? GetById(Guid id);
        List<T> GetAll();
    }
}