using System.Globalization;

namespace HHT.Pages;

public class TaskItem
{
    public string Description { get; set; }
    public bool IsChecked { get; set; }
}
public partial class ObjectivesPage : ContentPage
{
    
    
     private DateTime currentMonth = DateTime.Today;
    private DateTime selectedDate = DateTime.Today;

    // Stockage des objectifs en mémoire (clé = date, valeur = liste des tâches)
    private Dictionary<DateTime, List<TaskItem>> objectifsParDate = new();

    public ObjectivesPage()
    {
        InitializeComponent();
        DisplayDaysForMonth(currentMonth);
        DisplayTasksForDate(selectedDate);
        this.Title = string.Empty;
    }

    // Afficher les jours du mois courant
    void DisplayDaysForMonth(DateTime month)
    {
        CalendarDaysStack.Children.Clear();
        MonthLabel.Text = month.ToString("MMMM yyyy", CultureInfo.CurrentCulture);

        int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);

        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime date = new DateTime(month.Year, month.Month, day);
            bool isToday = date.Date == DateTime.Today;
            bool isSelected = date.Date == selectedDate.Date;

            var dayFrame = new Frame
            {
                Padding = 10,
                BackgroundColor = isSelected ? Color.FromArgb("#036AC4") :
              isToday ? Color.FromArgb("#2B3674") : Color.FromArgb("#E5E9F2"),
                CornerRadius = 10,
                Content = new VerticalStackLayout
                {
                    Children =
                        {
                            new Label
                            {
                                Text = date.Day.ToString(),
                                FontSize = 14,
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = isSelected || isToday ? Colors.White : Colors.Black
                            },
                            new Label
                            {
                                Text = date.ToString("ddd", CultureInfo.CurrentCulture),
                                FontSize = 12,
                                HorizontalOptions = LayoutOptions.Center,
                                TextColor = isSelected || isToday ? Colors.White : Colors.Black
                            }
                        }
                }
            };

            // Tap gesture pour sélectionner un jour
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                selectedDate = date;
                DisplayDaysForMonth(currentMonth); // rafraîchir affichage pour marquer la sélection
                DisplayTasksForDate(selectedDate);
            };
            dayFrame.GestureRecognizers.Add(tapGesture);

            CalendarDaysStack.Children.Add(dayFrame);
        }
    }

    // Afficher les objectifs du jour sélectionné
    void DisplayTasksForDate(DateTime date)
    {
        TaskList.Children.Clear();

        if (objectifsParDate.TryGetValue(date.Date, out List<TaskItem> tasks) && tasks.Any())
        {
            foreach (var task in tasks)
            {
                var frame = new Frame
                {
                    CornerRadius = 10,
                    Padding = new Thickness(10),
                    BorderColor = Color.FromArgb("#E5E9F2"),
                    BackgroundColor = Colors.White,
                    Content = new Grid
                    {
                        ColumnDefinitions = new ColumnDefinitionCollection
                            {
                                new ColumnDefinition { Width = 30 },      // Checkbox
                                new ColumnDefinition { Width = GridLength.Star }, // Texte tâche
                                new ColumnDefinition { Width = 40 }       // Icônes
                            }
                    }
                };

                var grid = (Grid)frame.Content;

                // Checkbox avec état lié à la tâche
                var checkBox = new CheckBox
                {
                    IsChecked = task.IsChecked,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Color = Color.FromArgb("#036AC4")
                };
                checkBox.CheckedChanged += (s, e) =>
                {
                    task.IsChecked = e.Value;
                };
                grid.Add(checkBox, 0, 0);

                // Texte tâche
                var label = new Label
                {
                    Text = task.Description,
                    FontSize = 14,

                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Colors.Black
                };
                grid.Add(label, 1, 0);

                // Icônes Modifier et Supprimer (verticalement)
                var iconsLayout = new VerticalStackLayout
                {
                    Spacing = 8,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };

                var editIcon = new ImageButton
                {
                    Source = "edit1_icon.png", // Assure-toi que cette image est dans tes ressources
                    WidthRequest = 24,
                    HeightRequest = 24,
                    BackgroundColor = Colors.Transparent
                };
                editIcon.Clicked += (s, e) =>
                {
                    DisplayAlert("Modifier", $"Modifier l'objectif : {task.Description}", "OK");
                };

                var deleteIcon = new ImageButton
                {
                    Source = "delete_icon.png", // Assure-toi que cette image est dans tes ressources
                    WidthRequest = 24,
                    HeightRequest = 24,
                    BackgroundColor = Colors.Transparent
                };
                deleteIcon.Clicked += (s, e) =>
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        bool confirmed = await DisplayAlert("Supprimer", $"Supprimer l'objectif : {task.Description} ?", "Oui", "Non");
                        if (confirmed)
                        {
                            objectifsParDate[date].Remove(task);
                            DisplayTasksForDate(date);
                        }
                    });
                };

                iconsLayout.Add(editIcon);
                iconsLayout.Add(deleteIcon);

                grid.Add(iconsLayout, 2, 0);

                TaskList.Children.Add(frame);
            }
        }
        else
        {
            TaskList.Children.Add(new Label
            {
                Text = "Aucun objectif pour ce jour.",
                FontSize = 14,
                TextColor = Colors.Gray,
                HorizontalOptions = LayoutOptions.Center
            });
        }
    }


    // Boutons navigation mois
    void OnPreviousMonthClicked(object sender, EventArgs e)
    {
        currentMonth = currentMonth.AddMonths(-1);
        DisplayDaysForMonth(currentMonth);

        // Reset sélection au premier jour du mois
        selectedDate = new DateTime(currentMonth.Year, currentMonth.Month, 1);
        DisplayTasksForDate(selectedDate);
    }

    void OnNextMonthClicked(object sender, EventArgs e)
    {
        currentMonth = currentMonth.AddMonths(1);
        DisplayDaysForMonth(currentMonth);

        // Reset sélection au premier jour du mois
        selectedDate = new DateTime(currentMonth.Year, currentMonth.Month, 1);
        DisplayTasksForDate(selectedDate);
    }

    // Ajouter un objectif à la date sélectionnée
    async void OnAddTaskClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Nouvel objectif",
            $"Ajouter un objectif pour le {selectedDate.ToShortDateString()} :",
            "Ajouter", "Annuler", placeholder: "Description de l'objectif");

        if (!string.IsNullOrWhiteSpace(result))
        {
            if (!objectifsParDate.ContainsKey(selectedDate.Date))
                objectifsParDate[selectedDate.Date] = new List<TaskItem>();

            objectifsParDate[selectedDate.Date].Add(new TaskItem { Description = result, IsChecked = false });

            DisplayTasksForDate(selectedDate);
        }
    }
}
