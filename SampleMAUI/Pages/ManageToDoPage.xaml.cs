using System.Diagnostics;
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
        if(_isNew)
        {
            Debug.WriteLine("Add new item");
            await _dataService.AddToDoAsync(ToDo);
        }
        else
        {
            Debug.WriteLine("update todo item");
            await _dataService.UpdateToDoAsync(ToDo);
        }
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(System.Object sender, System.EventArgs e)
    {
        await _dataService.DeleteToDoAsync(ToDo.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
