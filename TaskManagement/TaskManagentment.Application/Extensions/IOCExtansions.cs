using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Extensions
{
    public static class IOCExtansions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AccountRequest).Assembly);
        }
    }
}
