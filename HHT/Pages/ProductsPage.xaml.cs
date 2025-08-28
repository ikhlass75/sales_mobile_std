using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HHT.Models;
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
        private async void LaitiersTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LaitiersPages());
        }
        private async void OnProductSelected(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = "Dentifrice",
                Brand = "Colgate",
                Description = "Un dentifrice blanchissant pour dents sensibles.",
                ImagePath = "dentifrice.png",
                Price = 25,
                Stock = 120,
                Sold = 40,
                Rating = 4
            };

            await Navigation.PushAsync(new ProductDetailPage(product));
        }

    }
}

