using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagetment.Domain.Entities;

namespace TaskManagement.Persistance.Configuration
{
    public class AppTaskConfiguration : IEntityTypeConfiguration<AppTask>
    {
        public void Configure(EntityTypeBuilder<AppTask> builder)
        {
            builder.Property(x => x.PriorityID).IsRequired(true);
            builder.Property(x=>x.AppUserID).IsRequired(false);

            builder.Property(x=>x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(200);

            builder.HasMany(x => x.TaskReports)
                .WithOne(x => x.AppTask)
                .HasForeignKey(x => x.AppTaskID);
        }
    }
}
