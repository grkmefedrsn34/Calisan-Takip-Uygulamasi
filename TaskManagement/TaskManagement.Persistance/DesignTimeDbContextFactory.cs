using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagement.Persistance.Context;

namespace TaskManagement.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskManagementContext>
    {
        public TaskManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskManagementContext>();

            // appsettings.json kullanılmaz! Connection string doğrudan burada verilir.
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskManagement;Integrated Security=True;");

            return new TaskManagementContext(optionsBuilder.Options);
        }
    }
}
