using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Persistance.Context;
using TaskManagement.Persistance.Repository;
using TaskManagentment.Application.Interfaces;

namespace TaskManagement.Persistance
{
    public static class IOCExtensions
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();

        }


    }
}
