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

            bool isDarkMode = Preferences.Default.Get("DarkModeEnabled", false);
            App.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;

            MainPage = new AppShell();

            // Navigation asynchrone après initialisation
            MainPage.Dispatcher.Dispatch(async () =>
            {
                await Shell.Current.GoToAsync("//splash");
            });
        }

    }
}
