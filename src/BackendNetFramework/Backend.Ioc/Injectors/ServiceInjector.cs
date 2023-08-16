using Backend.Application.Services;
using Backend.Domain.Services;
using SimpleInjector;

namespace Backend.Ioc.Injectors
{
    internal static class ServiceInjector
    {
        public static Container AddServicesInjector(this Container container)
        {
            container.Register<IPokemonService, PokemonService>(Lifestyle.Scoped);
            container.Register<IMestrePokemonService, MestrePokemonService>(Lifestyle.Scoped);

            return container;
        }
    }
}