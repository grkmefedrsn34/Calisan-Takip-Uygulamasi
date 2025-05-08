using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetment.Domain.Entities
{
    public class AppTask : BaseEntitiy
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int AppUserID { get; set; }
        public int PriorityID { get; set; }
        //LookUp
        public bool State { get; set; }

        public AppUser? AppUser { get; set; } 
        public Priority? Priority { get; set; }
        public List<TaskReport>? TaskReports { get; set; }
    }
}
