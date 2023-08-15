using Backend.Domain.Repositories;
using Backend.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class RepositoryInjector
{
    public static IServiceCollection AddRepositoriesInjector(this IServiceCollection services)
    {
        return services.AddScoped<IMestrePokemonRepository, MestrePokemonRepository>();
    }
}