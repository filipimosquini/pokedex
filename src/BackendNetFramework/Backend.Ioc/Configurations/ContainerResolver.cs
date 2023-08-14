using Backend.Ioc.Injectors;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Backend.Ioc.Configurations
{
    public static class ContainerResolver
    {
        public static SimpleInjectorWebApiDependencyResolver Resolve()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.ResolveUnregisteredConcreteTypes = true;

            container
                .AddHttpClientInjector()
                .AddValidationsInjector()
                .AddRepositoriesInjector();

            container.Verify();

            return new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}