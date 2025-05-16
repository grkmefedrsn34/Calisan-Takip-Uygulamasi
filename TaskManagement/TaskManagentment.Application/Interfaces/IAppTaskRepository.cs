using TaskManagetment.Domain.Entities;
using TaskManagentment.Application.DTOs;

public interface IAppTaskRepository
{
    Task<PagedData<AppTask>> GetAllAsync(int activePage, int pageSize = 10);
}
