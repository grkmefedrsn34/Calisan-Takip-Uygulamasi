using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagentment.Application.DTOs
{
    public record Response<T>(T Data, bool IsSuccess, string ErrorMessage,List<ValidationErorrs>? Erorrs);
    public record ValidationErorrs(string PropertyName, string ErorrMessage);
    public record NoData();
}
