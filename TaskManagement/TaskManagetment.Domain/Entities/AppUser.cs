using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetment.Domain.Entities
{
    public class AppUser : BaseEntitiy
    {
        public string UserName { get; set; } = null!; 
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int AppRoleID { get; set; }
        public AppRole? appRole { get; set; }
        public List<AppTask>? AppTasks { get; set; }
        public List<Notfication>? Notfications { get; set; }

    }
}
