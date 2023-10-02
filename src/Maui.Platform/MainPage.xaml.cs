using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using Maui.Platform.Model;
using Maui.Platform.Seevices;
using System.Diagnostics;
using System.Text;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Maui.Platform
{
    public partial class MainPage : ContentPage
    {


        private readonly IAppInfo _appInfo;
        private readonly ILauncher _launcher;
        private readonly IMap _map;
        private readonly IContacts _contacts;
        private readonly IBattery _battery;
        private readonly IDeviceDisplay _deviceDisplay;
        private readonly IDeviceInfo _deviceInfo;
        private readonly IAccelerometer _accelerometer;
        private readonly IFlashlight _flashlight;
        private readonly IGeocoding _geocoding;
        private readonly IGeolocation _geolocation;
        private readonly IHapticFeedback _hapticFeedback;
        private readonly IVibration _vibration;
        private readonly IMediaPicker _mediaPicker;
        private readonly IScreenshot _screenshot;
        private readonly ITextToSpeech _textToSpeech;
        private readonly IClipboard _clipboard;
        private readonly IShare _share;
        private readonly IFilePicker _filePicker;
        private readonly IFileSystem _fileSystem;
        private readonly IPreferences _preferences;
        private readonly ISecureStorage _secureStorage;
        private readonly IUserService _userService;
        private readonly IEmail _email;
        private readonly IConnectivity _connectivity;
        private readonly IPhoneDialer _phoneDialer;
        private readonly ISms _sms;

        public MainPage(IAppInfo appInfo, ILauncher launcher = null, IMap map = null, IContacts contacts = null, IBattery battery = null, IDeviceDisplay deviceDisplay = null, IDeviceInfo deviceInfo = null, IAccelerometer accelerometer = null, IFlashlight flashlight = null, IGeocoding geocoding = null, IGeolocation geolocation = null, IHapticFeedback hapticFeedback = null, IVibration vibration = null, IMediaPicker mediaPicker = null, IScreenshot screenshot = null, ITextToSpeech textToSpeech = null, IClipboard clipboard = null, IShare share = null, IFilePicker filePicker = null, IFileSystem fileSystem = null, IPreferences preferences = null, ISecureStorage secureStorage = null, IUserService userService = null, IEmail email = null, IConnectivity connectivity = null, IPhoneDialer phoneDialer = null, ISms sms = null)
        {
            InitializeComponent();
            _appInfo = appInfo;
            _launcher = launcher;
            _map = map;
            _contacts = contacts;
            _battery = battery;
            _deviceDisplay = deviceDisplay;
            _deviceInfo = deviceInfo;
            _accelerometer = accelerometer;
            _flashlight = flashlight;
            _geocoding = geocoding;
            _geolocation = geolocation;
            _hapticFeedback = hapticFeedback;
            _vibration = vibration;
            _mediaPicker = mediaPicker;
            _screenshot = screenshot;
            _textToSpeech = textToSpeech;
            _clipboard = clipboard;
            _share = share;
            _filePicker = filePicker;
            _fileSystem = fileSystem;
            _preferences = preferences;
            _secureStorage = secureStorage;
            _userService = userService;
            _email = email;
            _connectivity = connectivity;
            _phoneDialer = phoneDialer;
            _sms = sms;
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








            Button button = new Button().Text("联系人");
            button.Command = new Command(async () =>
            {

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
                var phone = string.Join("", contact.Phones.Select(o => o.PhoneNumber)); // List of phone numbers

                await DisplayAlert("提示", $"用户名：{displayName},电话号码为：{phone}", "OK");

            });

            Button button2 = new Button().Text("获取所有联系人");
            button2.Command = new Command(async () =>
            {
                StringBuilder sb = new StringBuilder();
                var names = GetContactNames();

                await foreach (var item in names)
                {
                    sb.AppendLine(item);
                }
                await DisplayAlert("获取所有联系人", $"{sb.ToString()}", "OK");

            });







            // 设置ListView的数据模板

            await ModalHelper.ShowScrollViewModalAsync(Navigation, "联系人", button, button2);
        }


        private async IAsyncEnumerable<string> GetContactNames()
        {
            var contacts = await _contacts.GetAllAsync();

            // No contacts
            if (contacts == null)
                yield break;

            foreach (var contact in contacts)
                yield return contact.DisplayName;
        }



        /// <summary>
        /// 电池
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Battery_Clicked(object sender, EventArgs e)
        {
            //if (DeviceInfo.Platform == DevicePlatform.WinUI)
            //{
            //    await DisplayAlert("提示", $"该平台下无法使用", "OK");
            //    return;
            //}



            Frame frame = new Frame
            {

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 6,
                    Children =
                {
                   new Label{
                       Text="电池状态:",

                   },
                       new Label{
                       Text=GetBatteryState(_battery.State),

                   },
                }
                }
            };


            Frame frame1 = new Frame
            {

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 6,
                    Children =
                {
                   new Label{
                       Text="电池电量:",

                   },
                       new Label{
                       Text= $"电池还有{_battery.ChargeLevel * 100}%电。",

                   },
                }
                }
            };


            Frame frame2 = new Frame
            {

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 6,
                    Children =
                {
                   new Label{
                       Text="节能模式:",

                   },
                       new Label{
                       Text=_battery.EnergySaverStatus.ToString(),

                   },
                }
                }
            };

            Frame frame3 = new Frame
            {

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 6,
                    Children =
                {
                   new Label{
                       Text="充电方式:",

                   },
                       new Label{
                       Text=BatteryPowerSource(_battery.PowerSource),

                   },
                }
                }
            };


            StackLayout stackLayout = new StackLayout { Margin = new Thickness(20), Spacing = 6 };
            stackLayout.Add(frame);
            stackLayout.Add(frame1);
            stackLayout.Add(frame2);
            stackLayout.Add(frame3);
            await ModalHelper.ShowModalAsync(Navigation, "电池", stackLayout);

        }

        /// <summary>
        /// 得到电池状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string GetBatteryState(BatteryState state)
        {
            return state switch
            {
                BatteryState.Charging => "电池正在充电。",
                BatteryState.Discharging => "充电器未连接，电池正在放电。",
                BatteryState.Full => "电池已满。",
                BatteryState.NotCharging => "电池没有充电。",
                BatteryState.NotPresent => "设备上没有电池。",
                BatteryState.Unknown => "电池未知",
                _ => "电池未知。"
            };
        }


        /// <summary>
        /// 得到充电方式
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string BatteryPowerSource(BatteryPowerSource source)
        {
            return source switch
            {
                Microsoft.Maui.Devices.BatteryPowerSource.Wireless => "无线充电",
                Microsoft.Maui.Devices.BatteryPowerSource.Usb => "USB端口充电",
                Microsoft.Maui.Devices.BatteryPowerSource.AC => "电池正在充电",
                Microsoft.Maui.Devices.BatteryPowerSource.Battery => "设备没有充电",
                _ => "未知"
            };
        }


        /// <summary>
        /// 设备显示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeviceDisplay_Clicked(object sender, EventArgs e)
        {

            Frame frame = new Frame
            {

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                       new Label{
                       Text=ReadDeviceDisplay(),

                   },
                }
                }
            };


            var @switch = new Microsoft.Maui.Controls.Switch
            {

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                ThumbColor = Colors.Pink
            };

            @switch.Toggled += (sender, e) =>
            {
                _deviceDisplay.KeepScreenOn = e.Value;

            };

            Frame frame1 = new Frame
            {

                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                {
                       new Label{
                       HorizontalOptions = LayoutOptions.Center,
                       VerticalOptions = LayoutOptions.Center,
                       Text="使屏幕保持打开状态",

                   },
                       @switch
                }
                }
            };
            StackLayout stackLayout = new StackLayout { Margin = new Thickness(20), Spacing = 6 };
            stackLayout.Add(frame);
            stackLayout.Add(frame1);
            await ModalHelper.ShowModalAsync(Navigation, "设备显示信息", stackLayout);
        }

        /// <summary>
        /// 读取设备显示
        /// </summary>
        private string ReadDeviceDisplay()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            Func<DisplayOrientation, string> orientaion = at =>
            {
                return at switch
                {
                    DisplayOrientation.Landscape => "横向",
                    DisplayOrientation.Portrait => "纵向",
                    _ => "未知。"
                };
            };
            Func<DisplayRotation, string> rotation = at =>
            {
                return at switch
                {
                    DisplayRotation.Rotation0 => "旋转0度",
                    DisplayRotation.Rotation90 => "旋转90度",
                    DisplayRotation.Rotation180 => "旋转180度",
                    DisplayRotation.Rotation270 => "旋转270度",
                    _ => "未知。"
                };
            };
            sb.AppendLine($"像素宽度: {_deviceDisplay.MainDisplayInfo.Width} / 像素高度: {_deviceDisplay.MainDisplayInfo.Height}");
            sb.AppendLine($"获取代表屏幕密度的值: {_deviceDisplay.MainDisplayInfo.Density}");
            sb.AppendLine($"获取设备的方向: {orientaion(_deviceDisplay.MainDisplayInfo.Orientation)}");
            sb.AppendLine($"方向的旋转角度: {rotation(_deviceDisplay.MainDisplayInfo.Rotation)}");
            sb.AppendLine($"刷新率: {_deviceDisplay.MainDisplayInfo.RefreshRate}");


            return sb.ToString();
        }

        private async void DeviceInfo_Clicked(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine($"设备的型号: {_deviceInfo.Model}");
            sb.AppendLine($"设备的制造商: {_deviceInfo.Manufacturer}");
            sb.AppendLine($"设备的名称: {_deviceInfo.Name}");
            sb.AppendLine($"系统版本: {_deviceInfo.VersionString}");
            sb.AppendLine($"获取设备类型: {_deviceInfo.Idiom}");
            sb.AppendLine($"获取设备平台: {_deviceInfo.Platform}");

            bool isVirtual = _deviceInfo.DeviceType switch
            {
                DeviceType.Physical => false,
                DeviceType.Virtual => true,
                _ => false
            };

            sb.AppendLine($"是否虚拟设备: {isVirtual}");



            Frame frame = new Frame
            {
                Margin = new Thickness(0, 0, 0, 10),
                Content = new StackLayout
                {


                    //Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(5),

                    Spacing = 15,
                    Children =
                {

                       new Label{

                      FontAttributes = FontAttributes.Bold,
                      Text=sb.ToString()

                      },
                }
                }
            };

            await ModalHelper.ShowModalAsync(Navigation, "设备信息", frame);
        }

        //设备传感器
        private async void Accelerometer_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("提示", $"该功能还没有实现", "OK");
        }

        /// <summary>
        /// 手电筒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Flashlight_Clicked(object sender, EventArgs e)
        {
            try
            {
                var @switch = new Microsoft.Maui.Controls.Switch
                {

                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    ThumbColor = Colors.Pink
                };

                @switch.Toggled += async (sender, e) =>
                {

                    if (e.Value)
                    {
                        await _flashlight.TurnOnAsync();
                    }
                    else
                    {
                        await _flashlight.TurnOffAsync();
                    }
                };
                Frame frame = new Frame
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    Content = new StackLayout
                    {


                        //Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(5),

                        Spacing = 15,
                        Children =
                {

                    @switch
                }
                    }
                };
                await ModalHelper.ShowModalAsync(Navigation, "手电筒", frame);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException ex)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }

        }

        /// <summary>
        /// 地理编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Geocoding_Clicked(object sender, EventArgs e)
        {






            var button = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "使用地理编码",

            };
            button.Clicked += Geocoding1_Clicked;

            var button1 = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "反向地理编码",

            };
            button1.Clicked += GetGeocodeReverseData;

            await ModalHelper.ShowModalAsync(Navigation, "地理编码", button, button1);

        }

        private async void Geocoding1_Clicked(object sender, EventArgs e)
        {
            try
            {
                string address = "广州天河区";
                IEnumerable<Location> locations = await _geocoding.GetLocationsAsync(address);

                Location location = locations?.FirstOrDefault();


                if (location != null)
                {
                    await DisplayAlert("提示", $"地址：{address},纬度: {location.Latitude}, 经度: {location.Longitude}, 高度: {location.Altitude}", "OK");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("错误", $"错误为:{ex.Message}", "OK");
            }
        }

        private async void GetGeocodeReverseData(object sender, EventArgs e)
        {
            try
            {
                double latitude = 47.673988;
                double longitude = -122.121513;
                IEnumerable<Placemark> placemarks = await _geocoding.GetPlacemarksAsync(latitude, longitude);
                Placemark placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"行政区域: {placemark.AdminArea}");
                    sb.AppendLine($"国家代码: {placemark.CountryCode}");
                    sb.AppendLine($"国家名称: {placemark.CountryName}");
                    sb.AppendLine($"功能名称: {placemark.FeatureName}");
                    sb.AppendLine($"地理位置: {placemark.Locality}");
                    sb.AppendLine($"邮政编码: {placemark.PostalCode}");
                    sb.AppendLine($"子管理区域: {placemark.SubAdminArea}");
                    sb.AppendLine($"次级地点: {placemark.SubLocality}");
                    sb.AppendLine($"次干道: {placemark.SubThoroughfare}");
                    sb.AppendLine($"大道: {placemark.Thoroughfare}");
                    await DisplayAlert("提示", $"{sb.ToString()}", "确定");
                }


            }
            catch (Exception ex)
            {

                await DisplayAlert("错误", $"错误为:{ex.Message}", "OK");
            }
        }

        private async void Geolocation_Clicked(object sender, EventArgs e)
        {



            var lastButton = new Button
            {

                Margin = new Thickness(0, 0, 0, 10),
                Text = "获取最后一个已知位置",
                Command = new Command(async () => await GetCachedLocation())
            };

            var currButton = new Button
            {

                Margin = new Thickness(0, 0, 0, 10),
                Text = "获取当前位置",
                Command = new Command(async () => await GetCurrentLocation())
            };


            var checkMockButton = new Button
            {

                Margin = new Thickness(0, 0, 0, 10),
                Text = "两个位置之间的距离",
                Command = new Command(async () => await 两个位置之间的距离())
            };

            await ModalHelper.ShowModalAsync(Navigation, "地理位置", lastButton, currButton, checkMockButton);

        }

        /// <summary>
        /// 获取最后一个已知位置
        /// </summary>
        /// <returns></returns>
        private async Task GetCachedLocation()
        {
            try
            {

                Location location = await _geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"纬度: {location.Latitude}");
                    sb.AppendLine($"经度: {location.Longitude}");
                    sb.AppendLine($"高度: {location.Altitude}");
                    await DisplayAlert("提示", $"{sb.ToString()}", "OK");
                    return;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (FeatureNotEnabledException fneEx)
            {

            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            await DisplayAlert("提示", $"None", "OK");
        }




        /// <summary>
        /// 获取当前位置
        /// </summary>
        /// <returns></returns>
        private async Task GetCurrentLocation()
        {
            try
            {


                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));



                Location location = await _geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"纬度: {location.Latitude}");
                    sb.AppendLine($"经度: {location.Longitude}");
                    sb.AppendLine($"高度: {location.Altitude}");
                    await DisplayAlert("提示", $"{sb.ToString()}", "OK");
                    return;
                }

            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {

            }
            await DisplayAlert("提示", $"无", "OK");
        }

        private async Task 两个位置之间的距离()
        {
            Location boston = new Location(42.358056, -71.063611);
            Location sanFrancisco = new Location(37.783333, -122.416667);

            double miles = Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Miles);
            await DisplayAlert("提示", $"两个位置之间距离:{miles}", "OK");
        }


        /// <summary>
        /// 触觉反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Haptic_Clicked(object sender, EventArgs e)
        {


            var shortButton = new Button
            {

                Margin = new Thickness(0, 0, 0, 10),
                Text = "点击触觉反馈",
                Command = new Command(() => _hapticFeedback.Perform(HapticFeedbackType.Click))
            };

            var longPressButton = new Button
            {

                Margin = new Thickness(0, 0, 0, 10),
                Text = "轻敲触觉反馈",
                Command = new Command(() => _hapticFeedback.Perform(HapticFeedbackType.LongPress))
            };




            await ModalHelper.ShowModalAsync(Navigation, "触觉反馈消息", shortButton, longPressButton);
        }
        /// <summary>
        /// 振动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Vibration_Clicked(object sender, EventArgs e)
        {

            try
            {

                int secondsToVibrate = Random.Shared.Next(1, 7);
                TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);
                var button1 = new Button
                {

                    Margin = new Thickness(0, 0, 0, 10),
                    Text = "打开振动",
                    Command = new Command(() => _vibration.Vibrate(vibrationLength))
                };

                var button2 = new Button
                {

                    Margin = new Thickness(0, 0, 0, 10),
                    Text = "关闭振动",
                    Command = new Command(() => _vibration.Cancel())
                };

                await ModalHelper.ShowModalAsync(Navigation, "振动", button1, button2);
            }
            catch (Exception ex)
            {

                await DisplayAlert("错误", $"{ex.Message}", "OK");
            }
        }

        /// <summary>
        /// 照片和视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MediaPicker_Clicked(object sender, EventArgs e)
        {

            Image image = new Image()
            {

                Aspect = Aspect.AspectFill
            };

            var button = new Button()
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "选择照片",
                Command = new Command(async () =>
                {
                    if (_mediaPicker.IsCaptureSupported)
                    {
                        var fileResult = await _mediaPicker.PickPhotoAsync();

                        if (fileResult is not null)
                        {
                            image.Source = fileResult.FullPath;
                        }

                    }



                })
            };


            //打开相机以拍照
            var buttion2 = new Button()
            {

                Text = "拍照",
                Margin = new Thickness(0, 0, 0, 10),
                Command = new Command(async () =>
                {
                    if (_mediaPicker.IsCaptureSupported)
                    {
                        FileResult photo = await _mediaPicker?.CapturePhotoAsync();
                        if (photo is not null)
                        {
                            string localFilePath = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);


                            using FileStream localFileStream = File.OpenWrite(localFilePath);

                            using Stream sourceStream = await photo.OpenReadAsync();
                            await sourceStream.CopyToAsync(localFileStream);

                            image.Source = photo.FullPath;
                        }

                    }

                })
            };
            MediaElement mediaElement = new MediaElement();
            mediaElement.IsVisible = false;
            mediaElement.Aspect = Aspect.AspectFill;
            mediaElement.ShouldShowPlaybackControls = true;

            var buttion3 = new Button()
            {

                Text = "选择视频",
                Margin = new Thickness(0, 0, 0, 10),
                Command = new Command(async () =>
                {
                    if (_mediaPicker.IsCaptureSupported)
                    {
                        FileResult video = await _mediaPicker.PickVideoAsync();

                        if (video is not null)
                        {

                            //mediaElement.HeightRequest = 200;
                            //mediaElement.WidthRequest = 200;
                            //mediaElement.IsVisible = true;
                            //mediaElement.Source = MediaSource.FromFile(video.FullPath);
                            SetMediaElement(mediaElement, video.FullPath);
                            //await ModalHelper.ShowScrollViewModalAsync(Navigation, "照片和视频的媒体选取器", container);
                        }
                    }

                })
            };

            var buttion4 = new Button()
            {

                Text = "打开相机以拍摄视频",
                Margin = new Thickness(0, 0, 0, 10),
                Command = new Command(async () =>
                {
                    if (_mediaPicker.IsCaptureSupported)
                    {
                        FileResult video = await _mediaPicker.CaptureVideoAsync();

                        if (video != null)
                        {

                            //string localFilePath = Path.Combine(FileSystem.CacheDirectory, video.FileName);

                            //using Stream sourceStream = await video.OpenReadAsync();
                            //using FileStream localFileStream = File.OpenWrite(localFilePath);

                            //await sourceStream.CopyToAsync(localFileStream);
                            if (video is not null)
                            {
                                //SetMediaElement(mediaElement, video.FullPath);
                                SetMediaElement(mediaElement, video.FullPath);
                            }
                        }
                    }
                })
            };


            await ModalHelper.ShowScrollViewModalAsync(Navigation, "照片和视频的媒体选取器", button, buttion2, buttion3, buttion4, image, mediaElement);
        }



        private void SetMediaElement(MediaElement element, string path)
        {
            if (element.IsVisible == false)
                element.IsVisible = true;


            element.HeightRequest = 270;
            element.WidthRequest = 270;
            element.Source = MediaSource.FromFile(path);

        }

        /// <summary>
        /// 屏幕快照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Screenshot_Clicked(object sender, EventArgs e)
        {



            if (_screenshot.IsCaptureSupported)
            {
                IScreenshotResult screen = await _screenshot.CaptureAsync();

                Stream stream = await screen.OpenReadAsync();

                var imageSource = ImageSource.FromStream(() => stream);
                var image = new Microsoft.Maui.Controls.Image();

                image.Source = imageSource;
                await ModalHelper.ShowScrollViewModalAsync(Navigation, "捕获屏幕快照", image);

            }


        }

        /// <summary>
        /// 文本转语音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TextToSpeech_Clicked(object sender, EventArgs e)
        {

            //await _textToSpeech.SpeakAsync("Hello World");
            var entry = new Entry
            {
                Margin = new Thickness(0, 0, 0, 10),
                Placeholder = "请输入文本"
            };

            Button button = new Button
            {

                Margin = new Thickness(0, 0, 0, 10),
                Text = "文本转语音",
                Command = new Command(async () =>
                {

                    await _textToSpeech.SpeakAsync(string.IsNullOrEmpty(entry.Text) ? "Hello World" : entry.Text);
                })
            };

            await ModalHelper.ShowModalAsync(Navigation, "文本转语音", entry, button);
        }

        /// <summary>
        /// 单位转换器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UnitConverter_Clicked(object sender, EventArgs e)
        {

            var celsius = UnitConverters.FahrenheitToCelsius(32.0);
            await DisplayAlert("单位转换器", $"华氏度转换为摄氏度{celsius}", "OK");

        }

        /// <summary>
        /// 剪贴板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Clipboard_Clicked(object sender, EventArgs e)
        {

            Button button = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "设置剪贴板",
                Command = new Command(async () =>
                {

                    await _clipboard.SetTextAsync("该文本在UI中突出显示。");
                })

            };
            Label label = new Label();
            label.Margin = new Thickness(0, 0, 0, 10);
            Button readButton = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "读剪贴板",
                Command = new Command(async () =>
                {

                    string text = "";
                    text = await _clipboard.GetTextAsync();
                    label.Text = text;

                })

            };
            await ModalHelper.ShowModalAsync(Navigation, "剪贴板", button, readButton, label);

        }

        /// <summary>
        /// 共享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Share_Clicked(object sender, EventArgs e)
        {

            Button button = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "共享文本",
                Command = new Command(() =>
                {

                    _share.RequestAsync(new ShareTextRequest()
                    {

                        Text = "你好",
                        Title = "Share Text"
                    });
                })

            };

            Button shareFile = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "共享文件",
                Command = new Command(async () =>
                {

                    string fn = "Attachment.txt";
                    string file = System.IO.Path.Combine(FileSystem.CacheDirectory, fn);

                    File.WriteAllText(file, "Hello World");

                    await _share.RequestAsync(new ShareFileRequest
                    {
                        Title = "Share text file",
                        File = new ShareFile(file)
                    });
                })

            };
            Button shareMultipleFiles = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "共享多个文件",
                Command = new Command(async () =>
                {

                    string file1 = System.IO.Path.Combine(FileSystem.CacheDirectory, "Attachment1.txt");
                    string file2 = System.IO.Path.Combine(FileSystem.CacheDirectory, "Attachment2.txt");

                    File.WriteAllText(file1, "Content 1");
                    File.WriteAllText(file2, "Content 2");

                    await _share.RequestAsync(new ShareMultipleFilesRequest
                    {
                        Title = "Share multiple files",
                        Files = new List<ShareFile> { new ShareFile(file1), new ShareFile(file2) }
                    });
                })

            };

            await ModalHelper.ShowModalAsync(Navigation, "共享", button, shareFile, shareMultipleFiles);

        }

        /// <summary>
        /// 文件选取器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FilePicker_Clicked(object sender, EventArgs e)
        {
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { DevicePlatform.WinUI, new[] { ".cbr", ".cbz" } }, // file extension
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                });

            PickOptions options = new()
            {
                PickerTitle = "请选择一个文件",
                FileTypes = customFileType,
            };

            await PickAndShow(options);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await _filePicker.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }

        /// <summary>
        /// 文件系统帮助程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FileSystem_Clicked(object sender, EventArgs e)
        {
            string cacheDir = _fileSystem.CacheDirectory;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"缓存目录:{cacheDir}");
            string mainDir = _fileSystem.AppDataDirectory;
            sb.AppendLine($"应用数据目录:{mainDir}");
            await DisplayAlert("文件系统帮助程序", $"{sb.ToString()}", "OK");
        }

        /// <summary>
        /// 首选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Preferences_Clicked(object sender, EventArgs e)
        {
            // Set a string value:

            if (_preferences.ContainsKey("first_name"))
                _preferences.Set("first_name", "John");


            if (_preferences.ContainsKey("age"))
                _preferences.Set("age", 28);

            if (_preferences.ContainsKey("has_pets"))
                _preferences.Set("has_pets", true);


            string firstName = _preferences.Get("first_name", "Unknown");
            int age = _preferences.Get("age", -1);
            bool hasPets = _preferences.Get("has_pets", false);

            await DisplayAlert("提示", $"值为:firstName={firstName},age={age},hasPets={hasPets}", "OK");
        }

        /// <summary>
        /// 保护存储
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SecureStorage_Clicked(object sender, EventArgs e)
        {

            Button button = new Button
            {

                Text = "写入值",
                Command = new Command(async () =>
                {
                    await _secureStorage.SetAsync("oauth_token", "avbcvaaccccAAaaa");
                    await DisplayAlert("提示", $"写入成功!!!", "OK");

                }),
                Margin = new Thickness(0, 0, 0, 10),
            };

            Button button1 = new Button
            {

                Text = "读取值",
                Command = new Command(async () =>
                {

                    var text = await _secureStorage.GetAsync("oauth_token");
                    if (text != null)
                    {
                        await DisplayAlert("提示", $"读取值为:{text}", "OK");
                    }

                }),
                Margin = new Thickness(0, 0, 0, 10),
            };

            Button button2 = new Button
            {

                Text = "删除值",
                Command = new Command(async () =>
                {

                    var success = _secureStorage.Remove("oauth_token");
                    if (success)
                    {
                        await DisplayAlert("提示", $"删除成功", "OK");
                    }

                }),
                Margin = new Thickness(0, 0, 0, 10),
            };

            await ModalHelper.ShowModalAsync(Navigation, "保护存储", button, button1, button2);
        }

        public List<User> UserItems { get; set; } = new List<User>();

        /// <summary>
        /// 本地数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LocalData_Clicked(object sender, EventArgs e)
        {

            StackLayout layout = new StackLayout();
            var entry = new Entry
            {
                Margin = new Thickness(0, 0, 0, 10),
                Placeholder = "请输入名字",

            };
            var entry2 = new Entry

            {
                Margin = new Thickness(0, 0, 0, 10),
                Placeholder = "请输入年龄"
            };

            Button button = new Button
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "添加"

            };




            var listView = new ListView
            {
                ItemsSource = await _userService.GetListUserAsync()
            };
            button.Command = new Command(async () =>
            {
                var userText = entry.Text;
                var ageText = entry2.Text;

                if (string.IsNullOrEmpty(userText))
                {
                    await Toast.Make("请输入用户名!!", ToastDuration.Long).Show();
                    return;
                }

                if (!int.TryParse(ageText, out int result))
                {
                    await Toast.Make("年龄输入格式不对!!", ToastDuration.Long).Show();
                    return;
                }

                if (await _userService.ExistAsync(o => o.Name == userText))
                {


                    await Toast.Make("用户名已存在，请重新输入!!", ToastDuration.Long).Show();
                    return;
                }



                await _userService.AddUserAsync(userText, result);
                await Toast.Make("添加用户成功!!", ToastDuration.Long).Show();
                entry.Text = "";
                entry2.Text = "";
                listView.ItemsSource = null;
                listView.ItemsSource = await _userService.GetListUserAsync();
            });




            // 设置ListView的数据模板
            listView.ItemTemplate = new DataTemplate(() =>
            {


                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star }); // 第一列占满剩余空间
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto }); // 第二列自动宽度

                var nameLabel = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                var ageLabel = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                };
                ageLabel.SetBinding(Label.TextProperty, "Age");

                Grid.SetColumn(nameLabel, 0);
                Grid.SetColumn(ageLabel, 1);

                grid.Children.Add(nameLabel);
                grid.Children.Add(ageLabel);


                return new ViewCell { View = grid };
            });
            layout.Add(entry);
            layout.Add(entry2);
            layout.Add(button);
            layout.Add(listView);
            await ModalHelper.ShowScrollViewModalAsync(Navigation, "本地存储", layout);
        }

        /// <summary>
        /// 电子邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void Email_Clicked(object sender, EventArgs e)
        {
            if (_email.IsComposeSupported)
            {

                string subject = "你好朋友!";
                string body = "很高兴上周末见到你.";
                string[] recipients = new[] { "179722134@qq.com", "179722134@qq.com" };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                await _email.ComposeAsync(message);
            }
        }


        /// <summary>
        /// 网络
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Connectivity_Clicked(object sender, EventArgs e)
        {

            Button button = new Button().Text("网络的范围");
            button.Command = new Command(async () =>
            {
                StringBuilder sb = new StringBuilder();
                var networkAccess = _connectivity.NetworkAccess;
                switch (networkAccess)
                {
                    case NetworkAccess.Internet:
                        sb.AppendLine("本地和 Internet 访问。");
                        break;
                    case NetworkAccess.ConstrainedInternet:
                        sb.AppendLine("Internet 访问受限。 此值表示存在一个强制门户，其中提供了对 Web 门户的本地访问。 使用门户提供身份验证凭据后，将授予 Internet 访问权限。");
                        break;
                    case NetworkAccess.Local:
                        sb.AppendLine("仅限本地网络访问。");
                        break;
                    case NetworkAccess.None:
                        sb.AppendLine("没有可用的连接。");
                        break;
                    case NetworkAccess.Unknown:
                        sb.AppendLine("无法确定 Internet 连接。");
                        break;
                }

                await DisplayAlert("网络的范围", sb.ToString(), "确定");

            });


            new ConnectivityTest();
            await ModalHelper.ShowScrollViewModalAsync(Navigation, "网络", button);

        }

        /// <summary>
        /// 电话拨号程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PhoneDialer_Clicked(object sender, EventArgs e)
        {
            Editor editor = new Editor().Placeholder("请输入电话号码");
            Button button = new Button().Text("电话拨号");
            button.Command = new Command(() =>
            {

                if (_phoneDialer.IsSupported)
                {
                    _phoneDialer.Open(editor.Text);
                }
            });
            await ModalHelper.ShowScrollViewModalAsync(Navigation, "电话拨号", editor, button);
        }

        /// <summary>
        /// SMS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SMS_Clicked(object sender, EventArgs e)
        {
            Editor editor = new Editor().Placeholder("请输入接受者");
            Button button = new Button().Text("发短信");
            button.Command = new Command(async () =>
            {

                if (_sms.IsComposeSupported)
                {
                    //_phoneDialer.Open(editor.Text);
                    string[] recipients = new[] { editor.Text };
                    string text = "你好，我对你的花瓶很感兴趣。";

                    var message = new SmsMessage(text, recipients);
                    await _sms.ComposeAsync(message);

                }
            });
            await ModalHelper.ShowScrollViewModalAsync(Navigation, "SMS", editor, button);
        }

    }





}




