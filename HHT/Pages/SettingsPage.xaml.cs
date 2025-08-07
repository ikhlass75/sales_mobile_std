using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace HHT.Pages
{
    public partial class SettingsPage : ContentPage
    {
        const string DarkModeKey = "DarkModeEnabled";

        public SettingsPage()
        {
            InitializeComponent();

            // Charger et appliquer le thème stocké
            bool isDarkMode = Preferences.Default.Get(DarkModeKey, false);
            DarkModeSwitch.IsToggled = isDarkMode;
            ApplyTheme(isDarkMode);
        }

        private void OnDarkModeToggled(object sender, ToggledEventArgs e)
        {
            bool isDarkMode = e.Value;

            // Enregistrer l’état dans les préférences
            Preferences.Default.Set(DarkModeKey, isDarkMode);

            // Appliquer le thème
            ApplyTheme(isDarkMode);
        }

        private void ApplyTheme(bool darkModeEnabled)
        {
            Application.Current.UserAppTheme = darkModeEnabled ? AppTheme.Dark : AppTheme.Light;
        }
    }
}
