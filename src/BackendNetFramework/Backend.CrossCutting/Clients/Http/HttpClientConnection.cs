using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend.CrossCutting.Clients.Http;

public class HttpClientConnection : IHttpClientConnection
{
    protected HttpClient HttpClient { get; private set; }

    public HttpClientConnection(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<T> GetAsync<T>(string url) where T : class
    {
        try
        {
            using (var response = await HttpClient.GetAsync(url))
            {
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode >= HttpStatusCode.BadRequest)
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<T>(responseString);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<T> GetAsync<T>(string url, string resource = "", string query = "") where T : class
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