using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagentment.Application.DTOs
{
    public record LoginResponseData(string Name, string Surname, int roleID);
}
