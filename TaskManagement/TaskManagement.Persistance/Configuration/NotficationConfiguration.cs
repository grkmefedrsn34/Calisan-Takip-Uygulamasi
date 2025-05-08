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
    public class NotficationConfiguration : IEntityTypeConfiguration<Notfication>
    {
        public void Configure(EntityTypeBuilder<Notfication> builder)
        {
            builder.Property(x=>x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.State).IsRequired(true);

            builder.Property(x => x.AppUserID).IsRequired(true);

            
        }
    }
}
