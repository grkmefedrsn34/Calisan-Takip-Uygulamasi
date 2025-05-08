using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetment.Domain.Entities
{
    public class Notfication : BaseEntitiy
    {
        public string? Description { get; set; } = null!;
        public bool State { get; set; }
        public int AppUserID { get; set; }
        public AppUser? AppUser { get; set; } 
    }
}
