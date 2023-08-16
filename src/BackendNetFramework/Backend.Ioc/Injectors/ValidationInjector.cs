using Backend.Application.Validators;
using SimpleInjector;

namespace Backend.Ioc.Injectors
{
    internal static class ValidationInjector
    {
        public static Container AddValidationsInjector(this Container container)
        {
            container.Register<CapturarPokemonRequestValidator, CapturarPokemonRequestValidator>(Lifestyle.Scoped);
            container.Register<AdicionarMestrePokemonRequestValidator, AdicionarMestrePokemonRequestValidator>(Lifestyle.Scoped);
            container.Register<AtualizarMestrePokemonRequestValidator, AtualizarMestrePokemonRequestValidator>(Lifestyle.Scoped);

            return container;
        }
    }
}