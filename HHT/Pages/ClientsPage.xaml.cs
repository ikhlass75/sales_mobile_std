using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Maui.Controls;

namespace HHT.Pages
{
    public partial class ClientsPage : ContentPage
    {
        public ClientsPage()
        {
            InitializeComponent();
        }
        private async void OnVoirDetailsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("clientDetails");
        }
         
    }
}
