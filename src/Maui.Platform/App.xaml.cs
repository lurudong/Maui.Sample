namespace Maui.Platform
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += async (sender, args) =>
            {
                //Exception ex = (Exception)args.ExceptionObject;

                //await Shell.Current.DisplayAlert("全局错误", $"{ex.Message}", "OK");
                // 全局异常处理逻辑
            };

            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                Exception ex = args.Exception;
                // 全局异常处理逻辑
            };
            MainPage = new AppShell();
            // 设置全局异常处理程序

        }

        private void HandleGlobalException(object sender, UnhandledExceptionEventArgs e)
        {

            // 处理异常，例如记录异常信息或显示错误消息
            Console.WriteLine($"Global Exception:");
        }




    }
}