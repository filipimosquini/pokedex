using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.CrossCutting.Clients.http;

public class HttpClientConnection : IHttpClientConnection
{
    private readonly ILogger<HttpClientConnection> _logger;
    protected HttpClient HttpClient { get; private set; }

    public HttpClientConnection(HttpClient httpClient, ILogger<HttpClientConnection> logger)
    {
        _logger = logger;
        HttpClient = httpClient;
    }

    public async Task<T> GetAsync<T>(string url) where T : class
    {
        try
        {
            HttpClient.Timeout = TimeSpan.FromMinutes(2);

            using (var response = await HttpClient.GetAsync(url))
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode >= HttpStatusCode.BadRequest)
                {
                    _logger.LogError($" Status code: {response?.StatusCode} , Content: {response?.Content} ");

                    return null;
                }

                return JsonConvert.DeserializeObject<T>(responseString);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }

    public async Task<T> GetAsync<T>(string url, string resource = "", string query = "", string scheme = "", string parameter = "") where T : class
    {
        var completedUrl = url.EndsWith("/") ? url : $"{url}/";

        if (!string.IsNullOrWhiteSpace(resource))
        {
            completedUrl = $"{completedUrl}{resource}";
        }

        if (!string.IsNullOrWhiteSpace(query))
        {
            completedUrl = $"{completedUrl}{query}";
        }

        return await GetAsync<T>(completedUrl);
    }
}