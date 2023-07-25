using SampleMAUI.Models;

namespace SampleMAUI;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();

	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        /*var player1 = new Player
		{
			Name = "Erick",
			Info = "Mobile Legend Winner"
		};
		Binding playerBinding = new Binding();
		playerBinding.Source = player1;
		playerBinding.Path = "Name";
		playerData.SetBinding(Label.TextProperty, playerBinding);*/

        var player1 = new Player
        {
            Name = "Erick",
            Info = "Mobile Legend Winner"
        };
		BindingContext = player1;
    }

    void CounterBtn_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}


