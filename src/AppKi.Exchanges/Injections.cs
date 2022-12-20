using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppKi.Exchanges;

public static class Injections
{
    public static IServiceCollection AddExchanges(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}