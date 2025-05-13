using Microsoft.EntityFrameworkCore;
using TaskManagement.Persistance.Context;
using TaskManagentment.Application.Interfaces;
using TaskManagetment.Domain.Entities;

namespace TaskManagement.Persistance.Repository
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TaskManagementContext Context;
        public PriorityRepository(TaskManagementContext context)
        {
            Context = context;
        }
        public async Task<List<Priority>> GetAllAsync()
        {
            return await this.Context.Priorities.AsNoTracking().ToListAsync();
            throw new NotImplementedException();
        }
    }
}
