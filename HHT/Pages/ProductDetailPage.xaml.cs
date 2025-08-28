using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

using HHT.Models;
using Microsoft.Maui.Controls;

namespace HHT.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        private Product _product;

        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            _product = product;
            DisplayProductDetails();
        }

        private void DisplayProductDetails()
        {
            ProductName.Text = _product.Name;
            ProductBrand.Text = _product.Brand;
            ProductDescription.Text = _product.Description;
            ProductImage.Source = _product.ImagePath;
            ProductPrice.Text = $"{_product.Price} MAD";
            ProductStock.Text = $"Stock disponible : {_product.Stock}";
            ProductSold.Text = $"Vendus : {_product.Sold}";
            ProductRating.Text = $"Note : {_product.Rating}/5 ⭐";
        }

        private void OnUpdateStockClicked(object sender, EventArgs e)
        {
            _product.Stock += 10;
            ProductStock.Text = $"Stock disponible : {_product.Stock}";
        }

        private void OnAddSaleClicked(object sender, EventArgs e)
        {
            if (_product.Stock > 0)
            {
                _product.Stock--;
                _product.Sold++;
                ProductStock.Text = $"Stock disponible : {_product.Stock}";
                ProductSold.Text = $"Vendus : {_product.Sold}";
            }
        }
    }
}
