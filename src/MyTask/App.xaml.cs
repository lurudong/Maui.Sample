namespace MyTask
{
    public partial class App : Application
    {
        public App(AppShell appShell)
        {
            InitializeComponent();
            Current.UserAppTheme = AppTheme.Light;
            MainPage = appShell;
        }
    }
}