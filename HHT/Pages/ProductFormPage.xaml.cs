using HHT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Search;
using HHT.Models;
using Microsoft.Maui.Controls;

namespace HHT.Pages;

public partial class ProductFormPage : ContentPage
{
    private Product _product;
    private bool _isEditMode;

    public ProductFormPage(Product product = null)
    {
        InitializeComponent();

        if (product != null)
        {
            _product = product;
            _isEditMode = true;

            NameEntry.Text = product.Name;
            CategoryEntry.Text = product.Category;
            DescriptionEntry.Text = product.Description;
            QuantityEntry.Text = product.Quantity.ToString();
            SoldEntry.Text = product.Sold.ToString();
            PriceEntry.Text = product.Price.ToString();
            ImagePathEntry.Text = product.ImagePath;
        }
        else
        {
            _product = new Product();
            _isEditMode = false;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _product.Name = NameEntry.Text ?? "";
        _product.Category = CategoryEntry.Text ?? "";
        _product.Description = DescriptionEntry.Text ?? "";
        _product.Quantity = int.TryParse(QuantityEntry.Text, out int q) ? q : 0;
        _product.Sold = int.TryParse(SoldEntry.Text, out int s) ? s : 0;
        _product.Price = double.TryParse(PriceEntry.Text, out double p) ? p : 0;
        _product.ImagePath = ImagePathEntry.Text ?? "";

        // Retour à StockPage avec succès
        await DisplayAlert("Succès", _isEditMode ? "Produit modifié !" : "Produit ajouté !", "OK");
        await Navigation.PopAsync();
    }

    public Product GetProduct() => _product;
}

