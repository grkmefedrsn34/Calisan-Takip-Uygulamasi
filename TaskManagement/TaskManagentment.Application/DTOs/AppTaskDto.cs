using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagentment.Application.DTOs
{
    public record AppTaskListDto(int ID, string Title, string? Description, string? PriorityDefinition, bool? state);
}
