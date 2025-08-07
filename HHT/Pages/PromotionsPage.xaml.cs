using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace HHT.Pages
{
    public partial class PromotionsPage : ContentPage
    {
        public ObservableCollection<PromotionItem> Promotions { get; set; }

        public PromotionsPage()
        {
            InitializeComponent();
            Promotions = new ObservableCollection<PromotionItem>
            {
                new PromotionItem { Name = "Yaourt", Price = "Rp. 2,300", Image = "yoghurt.png" },
                new PromotionItem { Name = "Chocolat", Price = "Rp. 2,300", Image = "chocolat.png" },
                new PromotionItem { Name = "Sauce tomate", Price = "Rp. 2,300", Image = "sauce.png" },
                new PromotionItem { Name = "Limonade", Price = "Rp. 2,300", Image = "limonade.png" },
                new PromotionItem { Name = "Savon liquide", Price = "Rp. 2,300", Image = "savon.png" },
                new PromotionItem { Name = "Conserve de Thon", Price = "Rp. 2,300", Image = "thon.png" },
                new PromotionItem { Name = "Dentifrice", Price = "Rp. 2,300", Image = "dentifrice.png" },
                new PromotionItem { Name = "Huile d'Olive", Price = "Rp. 2,300", Image = "huile.png" },
                new PromotionItem { Name = "Boissons énergétiques", Price = "Rp. 2,300", Image = "boisson.png" },
            };

            BindingContext = this;
        }
    }

    public class PromotionItem
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}
