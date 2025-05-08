using Microsoft.EntityFrameworkCore;
using TaskManagement.Persistance.Configuration;
using TaskManagetment.Domain.Entities;


namespace TaskManagement.Persistance.Context
{
    public class TaskManagementContext: DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppTaskConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new NotficationConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskReportConfiguration());

        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppTask> AppTasks { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Notfication> Notfications { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<TaskReport> TaskReports { get; set; }
    }
}
