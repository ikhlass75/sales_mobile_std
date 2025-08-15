namespace HHT.Pages;

public partial class Objectives1Page : ContentPage
{
	public Objectives1Page()
	{
		InitializeComponent();
	}
    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox)
        {
            // On retrouve le Label qui est à côté du CheckBox
            if (checkbox.Parent is HorizontalStackLayout layout)
            {
                foreach (var element in layout.Children)
                {
                    if (element is Label label)
                    {
                        label.TextDecorations = checkbox.IsChecked
                            ? TextDecorations.Strikethrough
                            : TextDecorations.None;
                    }
                }
            }
        }
    }


}
