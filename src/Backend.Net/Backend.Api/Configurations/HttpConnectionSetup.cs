using System.Net.Http.Headers;
using Backend.CrossCutting.Clients.http;

namespace Backend.Api.Configurations;

public static class HttpConnectionSetup
{
    public static IServiceCollection AddingHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<IHttpClientConnection, HttpClientConnection>((sp, client) =>
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        return services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}