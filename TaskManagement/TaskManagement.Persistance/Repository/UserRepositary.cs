using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManagement.Persistance.Context;
using TaskManagetment.Domain.Entities;
using TaskManagentment.Application.Interfaces;

namespace TaskManagement.Persistance.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementContext _context;

        public UserRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _context.AppUsers.AsNoTracking().SingleOrDefaultAsync(filter);
            }
            return await _context.AppUsers.SingleOrDefaultAsync(filter);
        }
    }
}

