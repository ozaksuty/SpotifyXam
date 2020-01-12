using Acr.UserDialogs;
using SpotifyXam.Models;
using SpotifyXam.Services.Account;
using SpotifyXam.Services.Provider;
using SpotifyXam.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpotifyXam.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string username = "";

        private IList<Item> _items;
        public IList<Item> Items
        {
            get
            {
                if (_items == null)
                    _items = new ObservableCollection<Item>();
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        private readonly IProviderService _providerService;
        private readonly IAccountService _accountService;
        public MainPageViewModel(IProviderService providerService,
            IAccountService accountService)
        {
            _providerService = providerService;
            _accountService = accountService;

            Task.Run(GetAlbums);
        }

        public async Task GetAlbums()
        {
            IsBusy = true;
            await GetToken();
            var albums = await _providerService.Get<Album>($"https://api.spotify.com/v1/users/{username}/playlists");
            foreach (var item in albums.items)
                Items.Add(item);
            IsBusy = false;
        }

        public async Task GetToken()
        {
            await _accountService.GetAccessToken();
        }

        public ICommand SelectCommand => new Command(async (o) =>
        {
            if (o != null && o is Item playlist)
            {
                IsBusy = true;
                var tracks = await _providerService.Get<Playlist>($"https://api.spotify.com/v1/playlists/{playlist.id}/tracks");
                string trackNames = "";
                foreach (var item in tracks.Items)
                    trackNames += item.Track.Name + "\n";

                UserDialogs.Instance.Alert(new AlertConfig
                {
                    Message = trackNames,
                    Title = "Tracks",
                    OkText = "Ok"
                });

                IsBusy = false;
            }
        });
    }
}