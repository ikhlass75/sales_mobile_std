using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace HHT.Pages
{
    public partial class CommandesPage : ContentPage
    {
        public ObservableCollection<Commande> Commandes { get; set; }

        public CommandesPage()
        {
            InitializeComponent();

            Commandes = new ObservableCollection<Commande>
            {
                new Commande { ClientNom = "Ahmed", DateCommande = DateTime.Now, ProduitsCommandes = "Brosse à dents, Gel douche" },
                new Commande { ClientNom = "Sara", DateCommande = DateTime.Now.AddDays(-1), ProduitsCommandes = "Mouchoirs, Vaseline" },
                new Commande { ClientNom = "Youssef", DateCommande = DateTime.Now.AddDays(-2), ProduitsCommandes = "Lingettes nettoyantes" }
            };

            BindingContext = this;
        }
    }

    public class Commande
    {
        public string ClientNom { get; set; } = string.Empty;
        public DateTime DateCommande { get; set; }
        public string ProduitsCommandes { get; set; } = string.Empty;
    }
}
