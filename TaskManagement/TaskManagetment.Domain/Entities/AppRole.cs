using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetment.Domain.Entities
{
    public class AppRole : BaseEntitiy
    {
        public string Definition { get; set; } = null!;
        public List<AppUser>? Users { get; set; } 
    }
}
