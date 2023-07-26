using SampleMAUI.DataServices;
using SampleMAUI.Models;

namespace SampleMAUI.Pages;

[QueryProperty(nameof(ToDo),"ToDo")]
public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;
    private bool _isNew;
    ToDo _toDo;
    public ToDo ToDo
    {
        get => _toDo;
        set
        {
            _isNew = IsNew(value);
            _toDo = value;
            OnPropertyChanged();
        }
    }

    bool IsNew(ToDo toDo)
    {
        if (toDo.Id == 0)
            return true;
        return false;
    }

    public ManageToDoPage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
        BindingContext = this;
	}

    async void OnSaveButtonClicked(System.Object sender, System.EventArgs e)
    {
        await _dataService.AddToDoAsync(ToDo);
        await Shell.Current.GoToAsync("..");
    }

    
}
