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
    public class AppUserConfiguration: IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Surname).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(100);

            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(100);

            builder.HasIndex(x => x.UserName).IsUnique(true);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.UserName).HasMaxLength(100);

            builder.Property(x => x.AppRoleID).IsRequired(true);

            builder.HasMany(x => x.AppTasks).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);
            builder.HasMany(x => x.Notfications).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);
        }
    }

}
