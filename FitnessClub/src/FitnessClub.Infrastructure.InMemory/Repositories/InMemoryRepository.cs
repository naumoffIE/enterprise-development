namespace FitnessClub.Infrastructure.InMemory.Repositories;
public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly List<TEntity> _items = [];
    private int _nextId = 1;
    public Task<IReadOnlyList<TEntity>> GetAllAsync()
        => Task.FromResult<IReadOnlyList<TEntity>>([.. _items]);
    public Task<TEntity?> GetByIdAsync(int id)
        =>  Task.FromResult(_items.FirstOrDefault(e => e.Id == id));
    public Task<TEntity> AddAsync(TEntity entity)
    {
        // добавить lock`и ???
        entity.Id = _nextId++;
        _items.Add(entity);
        return Task.FromResult(entity);
    }
    public Task<bool> UpdateAsync(TEntity entity)
    {
        var index = _items.FindIndex(e => e.Id == entity.Id);
        if (index < 0)
            return Task.FromResult(false);
        _items[index] = entity;
        return Task.FromResult(true);
    }
    public Task<bool> DeleteAsync(int id)
    {
        var entity = _items.FirstOrDefault(e => e.Id == id);
        if (entity is null)
            return Task.FromResult(false);
        _items.Remove(entity);
        return Task.FromResult(true);
    }
} 