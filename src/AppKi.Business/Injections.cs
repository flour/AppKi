using AppKi.DataAccess;
using AppKi.Exchanges;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppKi.Business;

public static class Injections
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddMediator()
            .AddExchanges(configuration)
            .AddDataAccess(configuration);
    }
}