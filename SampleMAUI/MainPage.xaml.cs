using SampleMAUI.DataServices;
using SampleMAUI.Models;
using SampleMAUI.Pages;

namespace SampleMAUI;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _dataService;
    public MainPage(IRestDataService dataService)
	{
		InitializeComponent();
		_dataService = dataService;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
    }

    async void ToolbarItemAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            {nameof(ToDo),new ToDo()}
        };
        await Shell.Current.GoToAsync(nameof(ManageToDoPage),navigationParameter);
    }

    async void OnSelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            {nameof(ToDo),e.CurrentSelection.FirstOrDefault() as ToDo }
        };
        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }
}


