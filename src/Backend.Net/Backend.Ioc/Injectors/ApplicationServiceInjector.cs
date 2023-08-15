using Backend.Application.AppplicationServices;
using Backend.Application.AppplicationServices.Pokemons;
using Backend.Domain.ApplicationServices.MestresPokemons;
using Backend.Domain.ApplicationServices.Pokemons;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ApplicationServiceInjector
{
    public static IServiceCollection AddApplicationServicesInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<IPokemonApplicationService, PokemonApplicationService>()
            .AddScoped<IMestrePokemonApplicationService, MestrePokemonApplicationService>();
    }
}