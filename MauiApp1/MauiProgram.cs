using Microsoft.Extensions.Logging;
using MauiApp1.LR3.Services;
using MauiApp1.LR4.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MauiApp1
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
                });
            builder.Services.AddTransient<IDbService, SQLiteService>();
            builder.Services.AddTransient<Laba3>();

            builder.Services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri("https://api.nbrb.by/exrates/rates/"));
            builder.Services.AddTransient<ConverterPage>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
