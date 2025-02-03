using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Domain.Services;
using Fotovoltaico.Maui.Pages;
using Fotovoltaico.Maui.ViewModels;
using Microsoft.Extensions.Logging;

namespace Fotovoltaico.Maui
{
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
                })
                .RegisterAppService()
                .RegisterViews();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5000/api/")
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppService(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<IPersonService, PersonService>();
            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            app.Services.AddTransient<PersonPage>();
            return app;
        }
    }
}
