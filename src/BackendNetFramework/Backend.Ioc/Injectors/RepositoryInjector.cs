using Backend.Domain.Repositories;
using Backend.Infra.Configurations;
using Backend.Infra.Contexts;
using Backend.Infra.Repositories;
using SimpleInjector;
using System.Configuration;

namespace Backend.Ioc.Injectors
{
    internal static class RepositoryInjector
    {
        public static Container AddRepositoriesInjector(this Container container)
        {
            container.Register<PokedexContext>(() =>
            {
                var connectionString = ConfigurationManager.AppSettings["SqliteConnection"];
                var optionsBuilder = EFCoreConnectionConfiguration.ConfigureBuilder();

                var context = new PokedexContext(optionsBuilder.Options, connectionString);

                return context;
            }, Lifestyle.Scoped);

            container.Register<IPokemonRepository, PokemonRepository>(Lifestyle.Scoped);
            container.Register<IMestrePokemonRepository, MestrePokemonRepository>(Lifestyle.Scoped);

            return container;
        }
    }
}