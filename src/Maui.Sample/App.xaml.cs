﻿namespace Maui.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appAction"></param>
        public static void HandleAppActions(AppAction appAction)
        {
            App.Current.Dispatcher.Dispatch(async () =>
            {

                var page = appAction.Id switch
                {
                    "battery_info" => new MainPage(),
                    "app_info" => new MainPage(),
                    _ => default(Page)
                };

                if (page != null)
                {
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(page);
                }
            });
        }
    }
}