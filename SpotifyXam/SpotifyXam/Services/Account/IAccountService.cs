using SpotifyXam.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SpotifyXam.Services.Account
{
    public interface IAccountService : IServiceBase
    {
        Task<AccessToken> GetAccessToken();
    }
}