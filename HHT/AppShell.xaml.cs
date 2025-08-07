using System;
using Microsoft.Maui.Controls;
using HHT.Pages;

namespace HHT
{
    public partial class AppShell : Shell
    {
        public Command NavigateToProfileCommand { get; }

        public AppShell()
        {
            InitializeComponent();

            // Commande pour le bouton "Voir le profil"
            NavigateToProfileCommand = new Command(async () =>
            {
                await GoToAsync("//profile");
            });

            BindingContext = this;

            // Enregistrement des routes de navigation
            Routing.RegisterRoute("splash", typeof(SplashPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("commandes", typeof(CommandesPage));
            Routing.RegisterRoute("produits", typeof(ProductsPage));
            Routing.RegisterRoute("clients", typeof(ClientsPage));
            Routing.RegisterRoute("stock", typeof(StockPage));
            Routing.RegisterRoute("promotions", typeof(PromotionsPage));
            Routing.RegisterRoute("parametres", typeof(SettingsPage));
            Routing.RegisterRoute("profile", typeof(ProfilePage));
            Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));

            // ✅ Lancer navigation vers Splash dès le démarrage
            NavigateToSplashAsync();
        }

        private async void NavigateToSplashAsync()
        {
            await Task.Delay(100); // laisser le temps au Shell d'être prêt
            await Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("splash");
            });
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("profile");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("login");
        }
    }
}
