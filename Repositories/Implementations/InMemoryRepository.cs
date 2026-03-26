using ProyectoInventario.repositories;

public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly List<T> _data = new List<T>();

    void IRepository<T>.Add(T entity)
    {
        _data.Add(entity);
    }

    List<T> IRepository<T>.GetAll()
    {
        return _data;
    }

    void IRepository<T>.Delete(Guid id)
    {
        var entity = _data.FirstOrDefault(x => x.Id == id);
        if (entity != null)
        {
            _data.Remove(entity);
        }
    }

    T? IRepository<T>.GetById(Guid id)
    {
        var entity = _data.FirstOrDefault(x => x.Id == id);
        return entity;
    }

    void IRepository<T>.Update(T entity)
    {
        var index = _data.FindIndex(x => x.Id == entity.Id);

        if (index != -1)
            _data[index] = entity;
    }
}