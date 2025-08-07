using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace HHT.Pages
{
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            NameEntry.Text = Preferences.Default.Get("UserName", string.Empty);
            EmailEntry.Text = Preferences.Default.Get("UserEmail", string.Empty);
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            Preferences.Default.Set("UserName", NameEntry.Text);
            Preferences.Default.Set("UserEmail", EmailEntry.Text);

            await DisplayAlert("Succès", "Profil mis à jour.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
