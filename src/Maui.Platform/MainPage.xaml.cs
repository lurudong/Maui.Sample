using System.Diagnostics;
using System.Text;

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

        public MainPage(IAppInfo appInfo, ILauncher launcher = null, IMap map = null, IContacts contacts = null, IBattery battery = null, IDeviceDisplay deviceDisplay = null, IDeviceInfo deviceInfo = null, IAccelerometer accelerometer = null, IFlashlight flashlight = null, IGeocoding geocoding = null, IGeolocation geolocation = null, IHapticFeedback hapticFeedback = null, IVibration vibration = null, IMediaPicker mediaPicker = null, IScreenshot screenshot = null, ITextToSpeech textToSpeech = null)
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
                    Spacing = 15,
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
                    Spacing = 15,
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
                    Spacing = 15,
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
                    Spacing = 15,
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
                Text = "使用地理编码",

            };
            button1.Clicked += GetGeocodeReverseData;

            await ModalHelper.ShowModalAsync(Navigation, "地理编码", button, button1);

        }

        private async void Geocoding1_Clicked(object sender, EventArgs e)
        {
            try
            {
                string address = "Microsoft Building 25 Redmond WA USA";
                IEnumerable<Location> locations = await _geocoding.GetLocationsAsync(address);

                Location location = locations?.FirstOrDefault();


                if (location != null)
                {
                    await DisplayAlert("提示", $"纬度: {location.Latitude}, 经度: {location.Longitude}, 高度: {location.Altitude}", "OK");
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
                    await DisplayAlert("提示", $"地理编码:{sb.ToString()}", "地理编码");
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



            var button = new Button()
            {
                Margin = new Thickness(0, 0, 0, 10),
                Text = "选择照片",
                Command = new Command(async () =>
                {
                    var fileResult = await _mediaPicker.PickPhotoAsync();

                    ScrollView scrollView = new ScrollView();
                    scrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;
                    scrollView.HorizontalScrollBarVisibility = ScrollBarVisibility.Always;

                    scrollView.Content = new VerticalStackLayout()
                    {

                       new Image
                       {
                           HeightRequest=100,
                           WidthRequest=100,

                           Source = fileResult.FullPath
                       }
                    };
                    //scrollView.Content = new StackLayout()
                    //{

                    //    Children = {
                    //    new Image
                    //   {
                    //       HeightRequest=200,
                    //       Source = fileResult.FullPath
                    //   }
                    //    }
                    //};


                    await ModalHelper.ShowModalAsync(Navigation, "选择图片", scrollView);
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
                            // save the file into local storage
                            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                            using Stream sourceStream = await photo.OpenReadAsync();
                            using FileStream localFileStream = File.OpenWrite(localFilePath);

                            await sourceStream.CopyToAsync(localFileStream);
                        }
                    }

                })
            };

            var buttion3 = new Button()
            {

                Text = "选择视频",
                Margin = new Thickness(0, 0, 0, 10),
                Command = new Command(async () =>
                {
                    if (_mediaPicker.IsCaptureSupported)
                    {
                        FileResult photo = await _mediaPicker.PickPhotoAsync();

                        if (photo != null)
                        {
                            // save the file into local storage
                            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                            using Stream sourceStream = await photo.OpenReadAsync();
                            using FileStream localFileStream = File.OpenWrite(localFilePath);

                            await sourceStream.CopyToAsync(localFileStream);
                            //await DisplayAlert("提示", $"保存的地址为：{localFilePath}", "OK");

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

                            string localFilePath = Path.Combine(FileSystem.CacheDirectory, video.FileName);

                            using Stream sourceStream = await video.OpenReadAsync();
                            using FileStream localFileStream = File.OpenWrite(localFilePath);

                            await sourceStream.CopyToAsync(localFileStream);
                            //await DisplayAlert("提示", $"保存的地址为：{localFilePath}", "OK");
                            Console.WriteLine($"拍摄视频地址为:{localFilePath}");
                        }
                    }

                })
            };
            await ModalHelper.ShowModalAsync(Navigation, "照片和视频的媒体选取器", button, buttion2, buttion3, buttion4);
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
                Image image = new Image();

                image.HeightRequest = 100;
                image.Source = imageSource;
                await ModalHelper.ShowModalAsync(Navigation, "捕获屏幕快照", image);

            }


        }

        /// <summary>
        /// 文本转语音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TextToSpeech_Clicked(object sender, EventArgs e)
        {
            await _textToSpeech.SpeakAsync("Hello World");
        }
    }
}



