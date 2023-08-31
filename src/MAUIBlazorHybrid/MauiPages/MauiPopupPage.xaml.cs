namespace MAUIBlazorHybrid.MauiPages;

public partial class MauiPopupPage
{

    public MauiPopupPage()
    {

        InitializeComponent();
        //scanner.Options = new BarcodeReaderOptions()
        //{
        //    Formats = BarcodeFormats.All,
        //    AutoRotate = true,

        //    Multiple = true
        //};
        //scanner.IsTorchOn = !scanner.IsTorchOn;


    }
    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        myImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
    }

    //    private void scanner_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    //    {
    //        scanner.IsDetecting = false;

    //        Close(e.Results[0].Value);
    //    }

    //    private void ReturnToBlazor_Clicked(object sender, EventArgs e)
    //    {

    //        Close();
    //    }
}