using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationHubSystem.Core.DTOs.WebRequest;

namespace NotificationHubSystem.Core.Interfaces.Helper
{
    public interface IHttpRequest
    {
        HTTPResponseDTO<T> Get<T>(string url, Dictionary<string, string> headers = default) where T : class;
        HTTPResponseDTO<T> Post<T>(string url, object obj, Dictionary<string, string> headers = default) where T : class;
        Task<HTTPResponseDTO<T>> GetAsync<T>(string url, Dictionary<string, string> headers = default) where T : class;
        Task<HTTPResponseDTO<T>> PostAsync<T>(string url, object obj, Dictionary<string, string> headers = default) where T : class;
    }
}
