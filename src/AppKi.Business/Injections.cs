using AppKi.Business.Services;
using AppKi.Business.Services.Internals;
using AppKi.DataAccess;
using AppKi.Domain.Identity;
using AppKi.Exchanges;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppKi.Business;

public static class Injections
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSignalR().Services  
            .AddMediator(opts => opts.ServiceLifetime = ServiceLifetime.Scoped)
            .AddExchanges(configuration)
            .AddDataAccess(configuration)
            .AddIdentity<AppKiUser, AppKiUserRole>()
            .AddEntityFrameworkStores<AppKiDbContext>().Services
            
            // services
            .AddScoped<IDataFeedService, DataFeedService>();
    }
}