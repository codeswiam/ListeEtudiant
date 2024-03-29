using ListeEtudiant.Views;
using Microsoft.Extensions.Logging;

namespace ListeEtudiant;

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
        
        builder.Services.AddSingleton<EtudiantListPage>();
        builder.Services.AddTransient<EtudiantPage>();

        builder.Services.AddSingleton<EtudiantDatabase>();

        return builder.Build();
    }
}