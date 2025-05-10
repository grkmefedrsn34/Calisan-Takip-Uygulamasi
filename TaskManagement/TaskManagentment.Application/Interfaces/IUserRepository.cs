using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskManagetment.Domain.Entities;

namespace TaskManagentment.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByFilter(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true);
    }
}
