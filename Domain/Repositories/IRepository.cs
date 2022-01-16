using System.Linq.Expressions;

namespace Domain.Repositories; 

public interface IRepository<TEntity> where TEntity : class {

    Task Create(TEntity entity);

    Task Update(TEntity entity);

    Task Delete(TEntity entity);

    Task<TEntity?> Read(int id);

    Task<List<TEntity>> Read(Expression<Func<TEntity, bool>> filter);

    Task<List<TEntity>> ReadAll(int start, int count);

}