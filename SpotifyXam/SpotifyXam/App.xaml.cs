using Autofac;
using SpotifyXam.Pages;
using SpotifyXam.Services;
using System.Reflection;
using Xamarin.Forms;

namespace SpotifyXam
{
    public partial class App : Application
    {
        public static IContainer _container;
        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Namespace.Contains("ViewModels"));

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AssignableTo<IServiceBase>()
                   .AsImplementedInterfaces()
                   .SingleInstance();

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
