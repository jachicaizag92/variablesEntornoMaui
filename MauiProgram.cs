using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using entorno.Config;

namespace entorno;
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

        builder.AddAppSettings();



#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Configuracion Variables de entorno


        // Registrar servicio para la inyeccion de dependencias en cualquier clase
        builder.Services.AddSingleton<IEnvironments, EnvironmentProvider>();

        return builder.Build();
    }

    //cargar la configuración desde un archivo JSON incrustado como recurso en el ensamblado
    private static void AddAppSettings(this MauiAppBuilder builder)
    {
        //Condicionales dependiendo el entorno a usar
#if DEBUG
        builder.AddJsonSettings("appsettings.json");
#endif
#if !DEBUG
        builder.AddJsonSettings("appsettings-development.json");
#endif

    }


    /*
     *Extension para el metod para MauiAppBuilder, para cargar la configuracion desde un archivo JSON incrustado como recurso en el ensamblado
     */
    private static void AddJsonSettings(this MauiAppBuilder builder, string fileName)
    {
        using Stream stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream($"entorno.{fileName}");

        if (stream != null)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);

        }

    }
}

