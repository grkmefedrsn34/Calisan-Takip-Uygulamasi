using System.Threading.Tasks;
using TaskManagetment.Domain.Entities;

namespace TaskManagentment.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByFilterAsync(System.Linq.Expressions.Expression<System.Func<AppUser, bool>> filter, bool asNoTracking = true);
        Task<int> CreateUserAsync(AppUser user);
    }
}
