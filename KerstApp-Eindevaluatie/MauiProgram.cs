using KerstApp_Eindevaluatie.Paginas;
using KerstApp_Eindevaluatie.Paginas.kerstlijst;
using KerstApp_Eindevaluatie.Paginas.personen;
using KerstApp_Eindevaluatie.Paginas.Wenslijstpaginass;
using KerstApp_Eindevaluatie.ViewModels;
using KerstApp_Eindevaluatie.ViewModels.Kertslijst;
using KerstApp_Eindevaluatie.ViewModels.persoonen;
using KerstApp_Eindevaluatie.ViewModels.Wenslijst;
using KerstAppBL.Interfaces;
using KerstAppBL.Services;
using KerstAppDL;
using Microsoft.Extensions.Logging;

namespace KerstApp_Eindevaluatie
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

            builder.Services.AddSingleton<IPersoonLiteDBrepository, PersoonLitedb>();
            builder.Services.AddSingleton<IWensLijstItemDbRepository, WensItemLiteDB>();
            builder.Services.AddSingleton<IKerstLijstItemRepository, KerstItemLiteDb>();


            builder.Services.AddSingleton<PersoonService>();
            builder.Services.AddSingleton<WenslijstItemService>();
            builder.Services.AddSingleton<KerstLijstItemService>();


            Routing.RegisterRoute("personen", typeof(PersonenePage));
            Routing.RegisterRoute("persoon-detail", typeof(PersonenVieewDetailpage));

            Routing.RegisterRoute("wenslijst", typeof(WensLijstPage));
            Routing.RegisterRoute("wenslijst-detail", typeof(WenslijstDetailPage));

            Routing.RegisterRoute("kerstlijst", typeof(KerstlijstPage));
            Routing.RegisterRoute("kerstlijst-detail", typeof(KerstlijstDetailPage));


            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<PersonenePage>();
            builder.Services.AddTransient<PersonenVieewDetailpage>();
            builder.Services.AddTransient<PersonenViewModel>();
            builder.Services.AddTransient<PersonenDetailViewModel>();

            builder.Services.AddTransient<WensLijstPage>();
            builder.Services.AddTransient<WenslijstDetailPage>();
            builder.Services.AddTransient<WensliijstVieuwModel>();
            builder.Services.AddTransient<WensLijstdetailViewModel>();

            builder.Services.AddTransient<KerstlijstPage>();
            builder.Services.AddTransient<KerstlijstDetailPage>();
            builder.Services.AddTransient<KerstlijstViewModel>();
            builder.Services.AddTransient<KerstlijstDetailViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
