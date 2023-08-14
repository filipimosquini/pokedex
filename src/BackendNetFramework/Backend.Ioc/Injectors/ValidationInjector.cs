using SimpleInjector;

namespace Backend.Ioc.Injectors
{
    internal static class ValidationInjector
    {
        public static Container AddValidationsInjector(this Container container)
        {
            return container;
        }
    }
}