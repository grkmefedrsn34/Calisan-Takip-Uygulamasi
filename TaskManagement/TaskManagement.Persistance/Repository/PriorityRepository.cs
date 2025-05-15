using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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
        public async Task<int> CreateAsync(Priority priority)
        {
            this.Context.Priorities.Add(priority);
            return await this.Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Priority priority)
        {
            this.Context.Priorities.Remove(priority);
           await this.Context.SaveChangesAsync();
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await this.Context.Priorities.AsNoTracking().ToListAsync();
        }

        public async Task<Priority?> GetByFilterAsync(Expression<Func<Priority, bool>> filter)
        {
            return await this.Context.Priorities.SingleOrDefaultAsync(filter);
        }

        public async Task<Priority?> GetByFilterAsNoTrackingAsync(Expression<Func<Priority, bool>> filter)
        {
            return await this.Context.Priorities.AsNoTracking().SingleOrDefaultAsync(filter);
        }
    }
}
