using System.Linq.Expressions;
using Model.Entities.Airships;

namespace Domain.Repositories.Interfaces; 

public interface IAirshipRepository : IRepository<Airship> {
    
    Task<List<Airship>> ReadGraphAsync(Expression<Func<Airship, bool>> filter);

}