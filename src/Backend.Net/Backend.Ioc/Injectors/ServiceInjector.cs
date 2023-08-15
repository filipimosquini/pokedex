using Backend.Application.Services;
using Backend.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ServiceInjector
{
    public static IServiceCollection AddServicesInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<IPokemonService, PokemonService>()
            .AddScoped<IMestrePokemonService, MestrePokemonService>();
    }
}