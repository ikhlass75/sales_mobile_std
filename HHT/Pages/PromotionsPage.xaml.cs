using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Maui.Controls;


namespace HHT.Pages
{
    public partial class PromotionsPage : ContentPage
    {
        private List<PromoItem> allPromos; // stocke tous les produits

        public PromotionsPage()
        {
            InitializeComponent();

            // Liste complète des promos
            allPromos = new List<PromoItem>
            {
                new PromoItem { Name="Yaghourt", Price="Rp. 2,300", Discount="50%", Image="yoghurt.png" },
                new PromoItem { Name="Chocolat", Price="Rp. 2,300", Discount="50%", Image="chocolat.png" },
                new PromoItem { Name="Sauce tomate", Price="Rp. 2,300", Discount="50%", Image="sauce.png" },
                new PromoItem { Name="Limonade", Price="Rp. 2,300", Discount="50%", Image="limonade.png" },
                new PromoItem { Name="Savon liquide", Price="Rp. 2,300", Discount="50%", Image="savon.png" },
                new PromoItem { Name="Conserve de Thon", Price="Rp. 2,300", Discount="50%", Image="thon.png" },
                new PromoItem { Name="Dentifrice", Price="Rp. 2,300", Discount="50%", Image="dentifrice.png" },
                new PromoItem { Name="Huile d'Olive", Price="Rp. 2,300", Discount="50%", Image="huile.png" },
                new PromoItem { Name="Boissons énergétiques", Price="Rp. 2,300", Discount="50%", Image="energy.png" },
            };

            PromosCollection.ItemsSource = allPromos;
        }

        // ——— Navigation back (Shell ou NavigationPage) ———
        private async void BackButton_Tapped(object sender, EventArgs e)
        {
            if (Shell.Current?.Navigation?.NavigationStack?.Count > 1)
                await Shell.Current.GoToAsync("..");
            else
                await Navigation.PopAsync();
        }

        private async void OnFavoriteTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Favori", "Produit ajouté aux favoris ❤️", "OK");
        }

        private async void OnAddToCartTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Panier", "Produit ajouté au panier 🛒", "OK");
        }

        // ——— Recherche: live + touche Entrée ———
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter(e.NewTextValue);
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            ApplyFilter(SearchEntry.Text);
        }

        private void ApplyFilter(string? text)
        {
            string searchText = (text ?? string.Empty).Trim().ToLowerInvariant();

            // Si champ vide -> tout afficher
            if (string.IsNullOrEmpty(searchText))
            {
                PromosCollection.ItemsSource = allPromos;
                return;
            }

            var filtered = allPromos
                .Where(p => (p.Name ?? string.Empty).ToLowerInvariant().Contains(searchText))
                .ToList();

            // Avec EmptyView, on peut mettre directement la liste filtrée (même si vide)
            PromosCollection.ItemsSource = filtered;
        }
    }

    // Modèle produit
    public class PromoItem
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Image { get; set; }
    }
}
