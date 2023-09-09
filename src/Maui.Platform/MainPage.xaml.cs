namespace Maui.Platform
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            //var openModalButton = new Button
            //{
            //    Text = "打开模态框"
            //};

            //openModalButton.Clicked += async (sender, args) =>
            //{
            //    var modalPage = new ContentPage
            //    {
            //        Content = new StackLayout
            //        {
            //            Children =
            //        {
            //            new Label
            //            {
            //                Text = "这是一个模态框",
            //                FontAttributes = FontAttributes.Bold,
            //                HorizontalOptions = LayoutOptions.CenterAndExpand,
            //                VerticalOptions = LayoutOptions.CenterAndExpand
            //            },
            //            new Button
            //            {
            //                Text = "关闭模态框",
            //                Command = new Command(async () =>
            //                {
            //                    await Navigation.PopModalAsync();
            //                })
            //            }
            //        }
            //        }
            //    };

            //    await Navigation.PushModalAsync(modalPage);
            //};

            //Content = new StackLayout
            //{
            //    Children = { openModalButton },
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    HorizontalOptions = LayoutOptions.CenterAndExpand
            //};
        }



        private async void Button_AppInfo(object sender, EventArgs e)
        {
            string name = AppInfo.Current.Name;
            string package = AppInfo.Current.PackageName;
            string version = AppInfo.Current.VersionString;
            string build = AppInfo.Current.BuildString;

            Frame frame1 = new Frame
            {
                Padding = new Thickness(5),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="应用程序名称:",
                       TextColor = Colors.Red,
                       FontSize = 18,
                       VerticalOptions = LayoutOptions.Center,
                   },
                       new Label{
                       Text = name,
                       FontSize = 18,
                       VerticalOptions = LayoutOptions.Center,
                   }
                }
                }
            };


            StackLayout stackLayout = new StackLayout { Margin = new Thickness(20) };
            stackLayout.Add(frame1);

            await ModalHelper.ShowModalAsync(Navigation, stackLayout);

        }


    }
}