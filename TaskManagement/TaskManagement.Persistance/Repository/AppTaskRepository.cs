using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagement.Persistance.Context;
using TaskManagement.Persistance.Extensions;
using TaskManagentment.Application.DTOs; // PagedData burada olmalı
using TaskManagentment.Application.Interfaces;
using TaskManagetment.Domain.Entities;

namespace TaskManagement.Persistance.Repository
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly TaskManagementContext _context;

        public AppTaskRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<TaskManagentment.Application.DTOs.PagedData<AppTask>> GetAllAsync(int activePage, int pageSize = 10)
        {
            var extPagedData = await _context.AppTasks
                .AsNoTracking()
                .ToPagedAsync(activePage, pageSize);  // Extensions.PagedData<AppTask>

            // Dönüşüm:
            var dtoPagedData = new TaskManagentment.Application.DTOs.PagedData<AppTask>(
                extPagedData.data,
                extPagedData.activePage,
                extPagedData.TotalRecords,
                extPagedData.pageSize
            );

            return dtoPagedData;
        }
    }
}
