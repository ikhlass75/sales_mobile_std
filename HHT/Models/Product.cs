using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HHT.Models;

public class Product
{
    public string Name { get; set; } = string.Empty;        // Nom du produit
    public string Category { get; set; } = string.Empty;    // Catégorie
    public string Description { get; set; } = string.Empty; // Description
    public string Brand { get; set; } = string.Empty;       // Marque
    public string ImagePath { get; set; } = string.Empty;   // Image du produit
    public int Quantity { get; set; }                       // Quantité en stock
    public int Sold { get; set; }                           // Nombre vendu
    public double Price { get; set; }                       // Prix
    public double Rating { get; set; }                      // Évaluation (ex: 4.5 étoiles)

    // Pour éviter la confusion : "Stock" = alias de Quantity
    public int Stock
    {
        get => Quantity;
        set => Quantity = value;
    }

}
