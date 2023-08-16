using Backend.CrossCutting.Clients.Http;
using SimpleInjector;
using System.Net.Http;

namespace Backend.Ioc.Injectors
{
    internal static class HttpClientInjector
    {
        public static Container AddHttpClientInjector(this Container container)
        {
            container.RegisterSingleton(() => new HttpClient());
            container.Register<IHttpClientConnection, HttpClientConnection>(Lifestyle.Scoped);

            return container;
        }
    }
}