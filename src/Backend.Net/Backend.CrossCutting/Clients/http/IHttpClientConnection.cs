namespace Backend.CrossCutting.Clients.http;

public interface IHttpClientConnection
{
    Task<T> GetAsync<T>(string url, string resource = "", string query = "") where T : class;
    Task<T> GetAsync<T>(string url) where T : class;
}