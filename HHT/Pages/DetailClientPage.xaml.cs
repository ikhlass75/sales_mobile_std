namespace HHT.Pages;

public partial class DetailClientPage : ContentPage
{
	public DetailClientPage()
	{
		InitializeComponent();
        this.Title = string.Empty;
         
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Console.WriteLine("NavigationStack count: " + Navigation.NavigationStack.Count);
        Console.WriteLine("ModalStack count: " + Navigation.ModalStack.Count);
    }


    private async void OnReglementClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("settlementDetails");
    }

   
    private async void OnCommandeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrderDetailsPage());
    }

}