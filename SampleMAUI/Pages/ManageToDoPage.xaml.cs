using SampleMAUI.DataServices;
using SampleMAUI.Models;

namespace SampleMAUI.Pages;

public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;

    public ManageToDoPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
	}

    async void OnSaveButtonClicked(System.Object sender, System.EventArgs e)
    {
        var todo = new ToDo
        {
            toDoName = entryName.Text
        };
        await _dataService.AddToDoAsync(todo);
        await Shell.Current.GoToAsync("..");
    }

    
}
