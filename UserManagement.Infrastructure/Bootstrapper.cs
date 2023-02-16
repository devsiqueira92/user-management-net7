using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddContexto(services, configurationManager);
        }

        private static void AddContexto(IServiceCollection services, IConfiguration configurationManager)
        {
            services.AddDbContext<UserManagementContext>(dbContext => {
                dbContext.UseSqlServer(configurationManager.GetConnectionString("Connection"));
            });
        }
    }
}
