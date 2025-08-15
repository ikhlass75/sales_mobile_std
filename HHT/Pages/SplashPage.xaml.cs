using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHT.Pages
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
           Shell.SetNavBarIsVisible(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
            StartTimer();
        }

        private async void StartTimer()
        {
            await Task.Delay(3000); // Attend 3 secondes
            await Shell.Current.GoToAsync("GpsActivation");
        }

    }
}