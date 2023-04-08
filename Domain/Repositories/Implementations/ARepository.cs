using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Implementations; 

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected SteamDbContext _steamDbContext;
    protected DbSet<TEntity> _table;

    public ARepository(SteamDbContext dbContext) {
        _steamDbContext = dbContext;
        _table = _steamDbContext.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity) {
        _table.Add(entity);
        await _steamDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity) {
        _table.Update(entity);
        await _steamDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity) {
        _table.Remove(entity);
        await _steamDbContext.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
        => await _table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
        => await _table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync(int start, int count)
        => await _table.Skip(start).Take(count).ToListAsync();
}