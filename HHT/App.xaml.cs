using Microsoft.Maui;
using Microsoft.Maui.Controls;
using HHT.Pages; // ➕ IMPORTANT pour voir LoginPage, HomePage, etc.

namespace HHT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Enregistrement des routes
            Routing.RegisterRoute("splash", typeof(SplashPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("profile", typeof(ProfilePage));

            bool isDarkMode = Preferences.Default.Get("DarkModeEnabled", false);
            App.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;

            // Affichage de la page de splash au lancement
            MainPage = new AppShell();
        }
    }
}
