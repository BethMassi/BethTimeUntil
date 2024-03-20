
using Microsoft.Extensions.Logging;
using Root.Interfaces;
using TimeUntilMAUI.Services;

namespace TimeUntilMAUI;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		// Add device specific services used by RCL (Root)
		builder.Services.AddSingleton<IFormFactor, FormFactor>();
        builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
        builder.Services.AddSingleton<IPhotoManager, PhotoManager>();        

        return builder.Build();
	}
}
