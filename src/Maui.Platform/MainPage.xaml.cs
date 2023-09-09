namespace Maui.Platform
{
    public partial class MainPage : ContentPage
    {

        private readonly IAppInfo _appInfo;

        public MainPage(IAppInfo appInfo)
        {
            InitializeComponent();
            _appInfo = appInfo;

        }



        private async void Button_AppInfo(object sender, EventArgs e)
        {
            string name = _appInfo.Name;
            string package = _appInfo.PackageName; //com.microsoft.myapp
            string version = _appInfo.VersionString;
            string build = _appInfo.BuildString;

            Frame frame1 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="程序名称:",
                       TextColor = Colors.Red

                   },
                       new Label{
                       Text = name
                   }
                }
                }
            };

            Frame frame2 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="程序标识符:", //例如 com.microsoft.myapp
                       TextColor = Colors.Red

                   },
                       new Label{
                       Text = package

                   }
                }
                }
            };

            Frame frame3 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="程序版本:", //例如 com.microsoft.myapp
                       TextColor = Colors.Red

                   },
                       new Label{
                       Text = version

                   }
                }
                }
            };


            Frame frame4 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="内部版本号:", //例如 com.microsoft.myapp
                       TextColor = Colors.Red

                   },
                       new Label{
                       Text = build

                   }
                }
                }
            };


            Frame frame5 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="当前主题:",
                       TextColor = Colors.Red

                   },
                       new Label{
                       Text = _appInfo.RequestedTheme.ToString()

                   }
                }
                }
            };

            Frame frame6 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="布局方向:",
                       TextColor = Colors.Red

                   },
                       new Label{
                       Text = _appInfo.RequestedLayoutDirection.ToString()

                   }
                }
                }
            };


            Frame frame7 = new Frame
            {
                Padding = new Thickness(5),
                BorderColor = Colors.Black,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                   new Label{
                       Text="打包模型:",
                       TextColor = Colors.Red

                   },
                      new Label{
                       Text = _appInfo.PackagingModel==AppPackagingModel.Packaged ? "打包":"未打包"

                   }
                }
                }
            };


            StackLayout stackLayout = new StackLayout { Margin = new Thickness(20), Spacing = 6 };
            stackLayout.Add(frame1);
            stackLayout.Add(frame2);
            stackLayout.Add(frame3);
            stackLayout.Add(frame4);
            stackLayout.Add(frame5);
            stackLayout.Add(frame6);
            stackLayout.Add(frame7);
            await ModalHelper.ShowModalAsync(Navigation, "应用信息", stackLayout);

        }


    }
}