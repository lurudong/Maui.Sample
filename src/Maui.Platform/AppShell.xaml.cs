namespace Maui.Platform
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SimplePopup), typeof(SimplePopup));
        }
    }
}