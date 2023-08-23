namespace HelloWorld
{
    /// <summary>
    /// 类似Startup吗？MVC中的Layout？
    /// App.xaml 文件包含应用范围的 XAML 资源，
    /// 例如颜色、样式或模板。 App.xaml.cs 
    /// 文件通常包含实例化 Shell 应用程序的代码。 在此项目中，它指向 AppShell 类。
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Current.UserAppTheme = AppTheme.Light;
            MainPage = new AppShell();
        }
    }
}