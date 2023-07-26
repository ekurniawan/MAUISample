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
        await Shell.Current.GoToAsync(nameof(ManageToDoPage));
    }
}


