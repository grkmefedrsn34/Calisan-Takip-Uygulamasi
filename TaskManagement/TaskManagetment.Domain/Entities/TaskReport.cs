using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetment.Domain.Entities
{
    public class TaskReport:BaseEntitiy
    {
        public string Definition { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public int AppTaskID { get; set; }
        public AppTask? AppTask { get; set; }
    }
}
