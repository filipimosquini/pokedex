using Backend.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Ioc.Injectors;

public static class ValidatorInjector
{
    public static IServiceCollection AddValidatorsInjector(this IServiceCollection services)
    {
        return services
            .AddScoped<CapturarPokemonRequestValidator, CapturarPokemonRequestValidator>()
            .AddScoped<AdicionarMestrePokemonRequestValidator, AdicionarMestrePokemonRequestValidator>()
            .AddScoped<AtualizarMestrePokemonRequestValidator, AtualizarMestrePokemonRequestValidator>();
    }
}