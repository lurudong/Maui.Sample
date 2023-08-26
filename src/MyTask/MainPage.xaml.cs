using MyTask.ViewModels;
namespace MyTask
{
    public partial class MainPage : ContentPage
    {



        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

    }
}