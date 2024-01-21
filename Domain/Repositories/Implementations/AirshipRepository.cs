using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities.Airships;

namespace Domain.Repositories.Implementations; 

public class AirshipRepository : ARepository<Airship>, IAirshipRepository {
    
    public AirshipRepository(SteamDbContext dbContext) : base(dbContext) {
        
    }
    public async Task<List<Airship>> ReadGraphAsync(Expression<Func<Airship, bool>> filter)
        => await _table
            .Include(t => t.MotorizationList)
            .ThenInclude(m => m.AEngine)
            .Where(filter)
            .ToListAsync();

    
}