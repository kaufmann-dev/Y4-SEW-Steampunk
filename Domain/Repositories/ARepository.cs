using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories; 

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{

    protected SteamDbContext _steamDbContext;
    protected DbSet<TEntity> _table;

    public async Task Create(TEntity entity)
    {
        _table.Add(entity);
        await _steamDbContext.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _table.Update(entity);
        await _steamDbContext.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        _table.Remove(entity);
        await _steamDbContext.SaveChangesAsync();
    }

    public async Task<TEntity?> Read(int id) {
        throw new NotImplementedException();
    }

    public async Task<List<TEntity>> Read(Expression<Func<TEntity, bool>> filter) {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> ReadAll(int start, int count) {
        throw new NotImplementedException();
    }
}