using SampleMAUI.DataServices;
using SampleMAUI.Models;

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
}


