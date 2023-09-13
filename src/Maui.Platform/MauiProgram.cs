using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Communication = Microsoft.Maui.ApplicationModel.Communication;

namespace Maui.Platform
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                 .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
            builder.Services.AddSingleton<ILauncher>(Launcher.Default);

            builder.Services.AddSingleton<IMap>(Map.Default);

            builder.Services.AddSingleton<IContacts>(Communication.Contacts.Default);
            builder.Services.AddSingleton<IBattery>(Battery.Default);
            builder.Services.AddSingleton<IDeviceDisplay>(DeviceDisplay.Current);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}