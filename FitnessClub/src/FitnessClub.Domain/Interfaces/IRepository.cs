using FitnessClub.Domain.Entities;
namespace FitnessClub.Domain.Interfaces;
public interface IRepository<TEntity> where TEntity : Entity
{
    public Task<IReadOnlyList<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(int id);
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<bool> DeleteAsync(int id);
}