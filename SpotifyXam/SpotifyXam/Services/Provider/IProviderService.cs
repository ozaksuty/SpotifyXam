using System.Threading.Tasks;

namespace SpotifyXam.Services.Provider
{
    public interface IProviderService : IServiceBase
    {
        Task<T> Get<T>(string url);
        Task<T> Post<T, K>(K request, string url);
    }
}