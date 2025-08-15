using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;

namespace HHT.Pages
{
    public partial class ProductsPage : ContentPage
    {
        public Command GoBackCommand { get; }

        public ProductsPage()
        {
            InitializeComponent();

            GoBackCommand = new Command(async () =>
            {
                await Navigation.PopAsync();
            });

            BindingContext = this;
        }

        private async void HygieneTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HygienePage());
        }
    }
}

