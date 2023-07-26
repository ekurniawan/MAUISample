using Microsoft.Extensions.Logging;
using SampleMAUI.DataServices;
using SampleMAUI.Pages;

namespace SampleMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddHttpClient<IRestDataService, RestDataService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<ManageToDoPage>();
        return builder.Build();
	}
}

