﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetment.Domain.Entities
{
    public class Priority : BaseEntitiy
    {
        public string  Definition { get; set; } = null!;
        public List<AppTask>? AppTasks { get; set; }
    }
}
