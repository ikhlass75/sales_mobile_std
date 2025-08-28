using HHT.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HHT.Pages;

public partial class StockPage : ContentPage
{
    public ObservableCollection<Product> Products { get; set; } = new();
    private List<Product> AllProducts { get; set; } = new();

    public StockPage()
    {
        InitializeComponent();
        LoadProducts();
        StockCollection.ItemsSource = Products;
    }

    private void LoadProducts()
    {
        AllProducts = new List<Product>
        {
            new Product { Name="Shampoing", Category="Hygiène", Description="Shampoing doux", Quantity=30, Sold=10, Price=25, ImagePath="shampooing.jpg" },
            new Product { Name="Dentifrice", Category="Hygiène", Description="Dentifrice blancheur", Quantity=50, Sold=20, Price=15, ImagePath="dentifrice.png" },
            new Product { Name="Lait", Category="Laitiers", Description="Lait demi-écrémé", Quantity=100, Sold=40, Price=8, ImagePath="lait.jpg" },
            new Product { Name="Sucre", Category="Épicerie", Description="Sucre blanc 1kg", Quantity=200, Sold=150, Price=12, ImagePath="sucre.jpg" }
        };

        Products.Clear();
        foreach (var item in AllProducts)
            Products.Add(item);
    }

    // Recherche
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue?.ToLower() ?? "";

        if (string.IsNullOrWhiteSpace(query))
        {
            Products.Clear();
            foreach (var item in AllProducts) Products.Add(item);
            SearchMessage.IsVisible = false;
        }
        else
        {
            var results = AllProducts
                .Where(p => p.Name.ToLower().Contains(query))
                .ToList();

            Products.Clear();
            foreach (var item in results) Products.Add(item);

            SearchMessage.Text = results.Any() ? "" : "❌ Désolé, ce produit n'existe pas.";
            SearchMessage.IsVisible = !results.Any();
        }
    }

    // Ajouter un produit
    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        var formPage = new ProductFormPage();
        await Navigation.PushAsync(formPage);

        var newProduct = formPage.GetProduct();
        if (newProduct != null)
        {
            Products.Add(newProduct);
            AllProducts.Add(newProduct);
        }
    }

    // Modifier un produit
    private async void OnEditProductClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is Product product)
        {
            var formPage = new ProductFormPage(product);
            await Navigation.PushAsync(formPage);
        }
    }

    // Supprimer un produit
    private async void OnDeleteProductClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is Product product)
        {
            bool confirm = await DisplayAlert("Confirmation", $"Supprimer {product.Name} ?", "Oui", "Non");
            if (confirm)
            {
                AllProducts.Remove(product);
                Products.Remove(product);
            }
        }
    }
}
