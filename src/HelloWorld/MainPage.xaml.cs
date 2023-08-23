using HelloWorld.ViewModels;

namespace HelloWorld
{
    /// <summary>
    /// 主页面，就像ASP.NET MVC中的Home/Index一样。
    /// </summary>
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            BindingContext = mainPageViewModel;
            //ListView listView = new ListView();
            //listView.SetBinding(ItemsView.ItemsSourceProperty, "Poetries");
        }

    }
}