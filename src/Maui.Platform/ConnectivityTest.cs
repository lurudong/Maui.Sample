using System.Text;

namespace Maui.Platform;

internal class ConnectivityTest
{
    public ConnectivityTest() =>
      Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

    ~ConnectivityTest() =>
        Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;

    async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        if (e.NetworkAccess == NetworkAccess.ConstrainedInternet)
            sb.AppendLine("Internet 访问受限。 ");

        else if (e.NetworkAccess != NetworkAccess.Internet)
            sb.AppendLine("本地和 Internet 访问。");

        var profiles = Connectivity.ConnectionProfiles;

        foreach (var item in profiles)
        {
            switch (item)
            {
                case ConnectionProfile.Bluetooth:
                    sb.AppendLine("蓝牙");
                    break;
                case ConnectionProfile.Cellular:
                    sb.AppendLine("移动/蜂窝数据连接。");
                    break;
                case ConnectionProfile.Ethernet:

                    sb.AppendLine("以太网数据连接。");
                    break;
                case ConnectionProfile.WiFi:
                    sb.AppendLine("Wi-Fi数据连接。");
                    break;
                default:
                    break;
            }
        }

        await Shell.Current.DisplayAlert("网络发生变更", sb.ToString(), "确定");
    }
}
