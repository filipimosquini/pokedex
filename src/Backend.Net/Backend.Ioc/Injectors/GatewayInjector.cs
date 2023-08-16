using Backend.Application.Gateways;
using Backend.Domain.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class GatewayInjector
{
    public static IServiceCollection AddGatewaysInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<IPokemonGateway, PokemonGateway>();
    }
}