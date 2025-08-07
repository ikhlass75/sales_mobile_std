using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls;

namespace HHT.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = new ProfileViewModel
            {
                FirstName = "Ikhlass",
                LastName = "Ryahi",
                DateOfBirth = "20-09-2003"
            };
        }

        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            // Logique de déconnexion à adapter selon ton système
            await DisplayAlert("Déconnexion", "Vous avez été déconnecté.", "OK");
            // await Shell.Current.GoToAsync("//LoginPage");
        }
    }

    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string DateOfBirth { get; set; }
    }
}
