using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Configuration;
using Newtonsoft.Json;

namespace Backend.CrossCutting.Clients.Http
{
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
                HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);

                HttpClient.Timeout = TimeSpan.FromMinutes(2);

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
            catch
            {
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
}