namespace HHT.Pages;

public partial class GpsActivationPage : ContentPage
{
	public GpsActivationPage()
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

    }
    private async void BtnVerifier_Clicked(object sender, EventArgs e)
    {
        bool gpsActive = await IsGpsEnabledAsync();

        if (gpsActive)
        {
            // Si GPS activ� ? Aller � la page d'authentification
            await Navigation.PushAsync(new LoginPage());
        }
        else
        {
            // Si GPS d�sactiv� ? Message d'erreur
            await DisplayAlert("GPS d�sactiv�",
                               "Veuillez activer la localisation (GPS) pour continuer.",
                               "OK");
        }
    }

    private async Task<bool> IsGpsEnabledAsync()
    {
        try
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(5)
            });

            return location != null; // Si on obtient une localisation ? GPS actif
        }
        catch (FeatureNotEnabledException)
        {
            return false; // GPS d�sactiv�
        }
        catch (PermissionException)
        {
            await DisplayAlert("Permission requise", "Veuillez autoriser l'acc�s � la localisation.", "OK");
            return false;
        }
        catch
        {
            return false;
        }
    }

}