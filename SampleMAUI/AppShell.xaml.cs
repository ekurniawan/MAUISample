﻿using SampleMAUI.Pages;

namespace SampleMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
	}
}

