using Autofac;
using SpotifyXam.Services.Account;
using SpotifyXam.Services.Provider;
using SpotifyXam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotifyXam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(App._container.Resolve<IProviderService>(),
            App._container.Resolve<IAccountService>());
        }
    }
}