using ZXing.Net.Maui;

namespace MAUIBlazorHybrid.MauiPages;

public partial class MauiPopupPage
{
    public MauiPopupPage()
    {

        InitializeComponent();
        scanner.Options = new BarcodeReaderOptions()
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,

            Multiple = true
        };
        scanner.IsTorchOn = !scanner.IsTorchOn;

    }

    private void scanner_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        scanner.IsDetecting = false;

        Close(e.Results[0].Value);
    }

    private void ReturnToBlazor_Clicked(object sender, EventArgs e)
    {

        Close();
    }
}