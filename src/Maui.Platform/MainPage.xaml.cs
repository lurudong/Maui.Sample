using System.Diagnostics;

namespace Maui.Platform
{
    public partial class MainPage : ContentPage
    {

        private readonly IAppInfo _appInfo;
        private readonly ILauncher _launcher;
        private readonly IMap _map;
        private readonly IContacts _contacts;

        public MainPage(IAppInfo appInfo, ILauncher launcher = null, IMap map = null, IContacts contacts = null)
        {
            InitializeComponent();
            _appInfo = appInfo;
            _launcher = launcher;
            _map = map;
            _contacts = contacts;
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


            var openButton = new Button
            {
                Text = "显示应用设置",
                Margin = new Thickness(0, 0, 0, 10),


            };
            openButton.Clicked += (sender, e) =>
            {
                _appInfo.ShowSettingsUI();
            };
            StackLayout stackLayout = new StackLayout { Margin = new Thickness(20), Spacing = 6 };
            stackLayout.Add(frame1);
            stackLayout.Add(frame2);
            stackLayout.Add(frame3);
            stackLayout.Add(frame4);
            stackLayout.Add(frame5);
            stackLayout.Add(frame6);
            stackLayout.Add(frame7);

            await ModalHelper.ShowModalAsync(Navigation, "应用信息", stackLayout, openButton);

        }

        /// <summary>
        /// 浏览器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BrowserOpen_Clicked(object sender, EventArgs e)
        {

            //BrowserLaunchMode 介绍请文档
            try
            {
                Uri uri = new Uri("https://www.microsoft.com");

                #region 简单
                //await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                #endregion

                #region 自定义
                BrowserLaunchOptions options = new BrowserLaunchOptions()
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Colors.Violet,
                    PreferredControlColor = Colors.SandyBrown
                };
                await Browser.Default.OpenAsync(uri, options);
                #endregion
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                await Shell.Current.DisplayAlert("错误", $"打开浏览器错误：{ex.Message}", "OK");
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }

        /// <summary>
        /// 启动器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Launcher_Clicked(object sender, EventArgs e)
        {

            string popoverTitle = "Read text file";
            string name = "File.txt";
            string file = System.IO.Path.Combine(FileSystem.CacheDirectory, name);

            System.IO.File.WriteAllText(file, "Hello World");
            await _launcher.OpenAsync(new OpenFileRequest(popoverTitle, new ReadOnlyFile(file)));
            #region 用手机测试
            //#region 通过文件打开另一个应用

            //var openButton = new Button
            //{
            //    Text = "通过文件打开另一个应用",
            //    Margin = new Thickness(0, 0, 0, 10)
            //};



            //openButton.Clicked += async (sender, e) =>
            //{

            //    try
            //    {


            //        await _launcher.OpenAsync(new OpenFileRequest(popoverTitle, new ReadOnlyFile(file)));
            //    }
            //    catch (Exception ex)
            //    {
            //        // 处理打开URL时可能出现的异常
            //        await DisplayAlert("Error", $"Unable to open URL: {ex.Message}", "OK");
            //    }
            //};




            //#endregion


            //#region 设置启动器位置 本部分仅适用于 iPadOS。
            //var shareOpenButton = new Button
            //{
            //    Text = "设置启动器位置",
            //    Margin = new Thickness(0, 0, 0, 10)
            //};

            //shareOpenButton.Clicked += async (sender, e) =>
            //{

            //    try
            //    {
            //        var element = sender as View;

            //        await Share.RequestAsync(new ShareFileRequest
            //        {
            //            Title = Title,
            //            File = new ShareFile(file),
            //            PresentationSourceBounds = element.GetAbsoluteBounds()
            //        });
            //        //await Share.Default.RequestAsync(new ShareTextRequest
            //        //{
            //        //    PresentationSourceBounds = element.GetAbsoluteBounds(),
            //        //    Title = "Title",
            //        //    Text = "Text"
            //        //});
            //    }
            //    catch (Exception ex)
            //    {
            //        // 处理打开URL时可能出现的异常
            //        await DisplayAlert("Error", $"Unable to open URL: {ex.Message}", "OK");
            //    }
            //};

            //#endregion


            //await ModalHelper.ShowModalAsync(Navigation, "启动器", openButton, shareOpenButton);
            #endregion
        }

        /// <summary>
        /// 地图与导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Map_Clicked(object sender, EventArgs e)
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions
            {
                Name = "Microsoft Building 25"
            };


            if (await _map.TryOpenAsync(location, options) == false)
            {
                await Shell.Current.DisplayAlert("错误", "地图无法打开", "OK");
            }
        }

        private async void Permissions_Clicked(object sender, EventArgs e)
        {
            PermissionStatus status = await CheckAndRequestLocationPermission();
            await DisplayAlert("Info", $"定位的权限为:{status}:{dic[status]}", "OK");
        }

        Dictionary<PermissionStatus, string> dic = new Dictionary<PermissionStatus, string>()
        {

            {  PermissionStatus.Unknown,"权限处于未知状态，或在 iOS 上从未提示过用户。"},
            {  PermissionStatus.Denied,"用户拒绝了权限请求。"},
            {  PermissionStatus.Disabled,"此功能在设备上处于禁用状态。"},
            {  PermissionStatus.Granted,"用户已授予权限或自动授予权限。"},
            {  PermissionStatus.Restricted,"处于受限状态。"},
            {  PermissionStatus.Limited,"处于受限状态。 只有 iOS 返回此状态。"},
        };
        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {

            //	https://learn.microsoft.com/zh-cn/dotnet/maui/user-interface/controls/map
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            //ios
            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //提示用户打开设置
                //在iOS系统上，一旦一个权限被拒绝，它可能不会再从应用程序请求
                return status;
            }

            //if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            //{
            //    //提示用户为什么需要该权限的附加信息
            //}

            //RequestAsync 没有声明权限会报错“PermissionException”
            status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();


            return status;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Contacts_Clicked(object sender, EventArgs e)
        {

            try
            {
                // 请求读取联系人权限
                var status = await Permissions.RequestAsync<Permissions.ContactsRead>();
                var status1 = await Permissions.RequestAsync<Permissions.ContactsWrite>();
                if (status != PermissionStatus.Granted && status1 != PermissionStatus.Granted)
                {
                    await DisplayAlert("错误", $"没有ContactsRead权限", "OK");
                    // 执行读取联系人的操作
                    return;
                }

                var contacts = await _contacts.GetAllAsync();

                //选择联系人
                var contact = await _contacts.PickContactAsync();

                if (contact == null)
                {
                    return;
                }
                string id = contact.Id;
                string namePrefix = contact.NamePrefix;
                string givenName = contact.GivenName;
                string middleName = contact.MiddleName;
                string familyName = contact.FamilyName;
                string nameSuffix = contact.NameSuffix;
                string displayName = contact.DisplayName;
            }
            catch (Exception ex)
            {

                await DisplayAlert("错误", $"{ex.Message}", "OK");
            }
        }
    }
}