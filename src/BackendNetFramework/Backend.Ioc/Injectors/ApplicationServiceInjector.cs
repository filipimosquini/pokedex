using Backend.Application.AppplicationServices;
using Backend.Domain.ApplicationServices.MestresPokemons;
using Backend.Domain.ApplicationServices.Pokemons;
using SimpleInjector;

namespace Backend.Ioc.Injectors
{
    internal static class ApplicationServiceInjector
    {
        public static Container AddApplicationServicesInjector(this Container container)
        {
            container.Register<IPokemonApplicationService, PokemonApplicationService>(Lifestyle.Scoped);
            container.Register<IMestrePokemonApplicationService, MestrePokemonApplicationService>(Lifestyle.Scoped);

            return container;
        }
    }
}