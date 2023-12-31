﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Maui.Platform.Model;
using Maui.Platform.Seevices;
using Microsoft.Extensions.Logging;
using Plugin.Maui.CalendarStore;
using UraniumUI;
using Communication = Microsoft.Maui.ApplicationModel.Communication;
using Constants = Maui.Platform.Help.Constants;

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
                .UseMauiCommunityToolkitMediaElement()
                .UseMauiCommunityToolkitMarkup()
                 .UseUraniumUI()
                 .ConfigureEssentials(essentials =>
                  {
                      essentials.UseMapServiceToken("Izj5JILe1xYXL0hTHW26~8oiFE11ZYPqSyuxSbUcy0w~AgBWKjMLiO3UjxZv2nck0nYUhmXSv_VE59N6_rLQmO0M_Owr_snfN7cDsbrQGNtI");
                  })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.UseMauiCommunityToolkit(options =>
            {
                options.SetShouldSuppressExceptionsInConverters(false);
                options.SetShouldSuppressExceptionsInBehaviors(false);
                options.SetShouldSuppressExceptionsInAnimations(false);
            });
            builder.Services.AddTransient<MainPage>();
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
            builder.Services.AddSingleton<IMediaPicker>(MediaPicker.Default);
            builder.Services.AddSingleton<IScreenshot>(Screenshot.Default);
            builder.Services.AddSingleton<ITextToSpeech>(TextToSpeech.Default);
            builder.Services.AddSingleton<IClipboard>(Clipboard.Default);
            builder.Services.AddSingleton<IShare>(Share.Default);
            builder.Services.AddSingleton<IFilePicker>(FilePicker.Default);
            builder.Services.AddSingleton<IFileSystem>(FileSystem.Current);
            builder.Services.AddSingleton<IPreferences>(Preferences.Default);
            builder.Services.AddSingleton<ISecureStorage>(SecureStorage.Default);
            builder.Services.AddSingleton<IEmail>(Email.Default);
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IPhoneDialer>(PhoneDialer.Default);
            builder.Services.AddSingleton<ISms>(Sms.Default);
            builder.Services.AddSingleton<IWebAuthenticator>(WebAuthenticator.Default);
            builder.Services.AddSingleton<ICalendarStore>(CalendarStore.Default);
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddSingleton<IDatabaseStorage>(_ =>
             {

                 var db = new DatabaseImp(new SQLite.SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));
                 db.Database.CreateTableAsync<User>().GetAwaiter();
                 return db;
             });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}