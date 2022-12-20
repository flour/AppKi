using AppKi.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppKi.DataAccess;

public static class Injections
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddIdentityCore<AppKiUser>().AddRoles<AppKiUserRole>().Services
            .AddDbContext<AppKiDbContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("default")));
    }
}