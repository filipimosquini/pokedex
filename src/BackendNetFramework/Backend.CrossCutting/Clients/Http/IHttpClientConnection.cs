using System.Threading.Tasks;

namespace Backend.CrossCutting.Clients.Http
{
    public interface IHttpClientConnection
    {
        Task<T> GetAsync<T>(string url, string resource = "", string query = "", string scheme = "", string parameter = "") where T : class;
        Task<T> GetAsync<T>(string url) where T : class;
    }
}