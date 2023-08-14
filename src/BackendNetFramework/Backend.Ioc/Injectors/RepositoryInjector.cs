using SimpleInjector;

namespace Backend.Ioc.Injectors
{
    internal static class RepositoryInjector
    {
        public static Container AddRepositoriesInjector(this Container container)
        {
            return container;
        }
    }
}