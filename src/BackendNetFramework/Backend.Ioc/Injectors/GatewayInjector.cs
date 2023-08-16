using Backend.Application.Gateways;
using Backend.Domain.Gateways;
using SimpleInjector;

namespace Backend.Ioc.Injectors
{
    internal static class GatewayInjector
    {
        public static Container AddGatewaysInjector(this Container container)
        {
            container.Register<IPokemonGateway, PokemonGateway>(Lifestyle.Scoped);

            return container;
        }
    }
}