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
                  .ConfigureEssentials(essentials =>
                  {
                      essentials.UseMapServiceToken("Izj5JILe1xYXL0hTHW26~8oiFE11ZYPqSyuxSbUcy0w~AgBWKjMLiO3UjxZv2nck0nYUhmXSv_VE59N6_rLQmO0M_Owr_snfN7cDsbrQGNtI");
                  })
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
            builder.Services.AddSingleton<IDeviceInfo>(DeviceInfo.Current);
            builder.Services.AddSingleton<IAccelerometer>(Accelerometer.Default);
            builder.Services.AddSingleton<IFlashlight>(Flashlight.Default);
            builder.Services.AddSingleton<IGeocoding>(Geocoding.Default);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IHapticFeedback>(HapticFeedback.Default);
            builder.Services.AddSingleton<IVibration>(Vibration.Default);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}