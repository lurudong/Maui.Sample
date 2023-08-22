using HelloWorld.ViewModels;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace HelloWorld
{
    public static class MauiProgram
    {
        /// <summary>
        /// 主程序入口，就像.NET CORE下Main函数一样，用来初始化，操作，假如DI注入，等一系列操作。
        /// </summary>
        /// <returns></returns>
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
            //builder.Services.AddSingleton<AppShell>();
            //builder.Services.AddTransient<MainPage>();
            //builder.Services.AddSingleton<MainPageViewModel>();

            ///注入使用自带的构造函数注入方式 
            ConfigureServices(builder.Services);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var types = Assembly.GetAssembly(typeof(MauiProgram))?.GetTypes().Where(o => o.IsClass && (typeof(ContentPage).IsAssignableFrom(o) || typeof(IViewModel).IsAssignableFrom(o)));

            foreach (var type in types)
            {
                if (typeof(ContentPage).IsAssignableFrom(type))
                {
                    services.AddTransient(type);

                }
                else if (typeof(IViewModel).IsAssignableFrom(type))
                {
                    services.AddSingleton(type);
                }


            }
        }
    }
}