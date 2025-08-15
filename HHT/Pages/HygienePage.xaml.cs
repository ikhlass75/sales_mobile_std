using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace HHT.Pages
{
    public partial class HygienePage : ContentPage
    {
        public HygienePage()
        {
            InitializeComponent();
        }

        private void BackButton_Tapped(object sender, EventArgs e)
        {
            // Logique pour gérer le retour, par exemple :
            Navigation.PopAsync();
        }
        private void OnProductStarTapped(object sender, EventArgs e)
        {
            if (sender is Image star && star.Parent is HorizontalStackLayout stack)
            {
                if (star.GestureRecognizers[0] is TapGestureRecognizer tap)
                {
                    int rating = int.Parse(tap.CommandParameter.ToString());
                    for (int i = 0; i < stack.Children.Count; i++)
                    {
                        if (stack.Children[i] is Image s)
                        {
                            s.Source = i < rating ? "star_filled.png" : "star_outline.png";
                        }
                    }
                }
            }
        }
    }
}
