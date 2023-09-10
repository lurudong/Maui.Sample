namespace Maui.Platform;

public class ModalHelper
{
    public static async Task ShowModalAsync(INavigation navigation, string title, params IView[] views)
    {
        var modalPage = new ContentPage();
        modalPage.Title = title;
        var stackLayout = new StackLayout()
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };


        foreach (var view in views)
        {
            stackLayout.Children.Add(view);
        }

        var button = new Button
        {
            Text = "关闭模态框",
            Command = new Command(async () =>
            {
                await navigation.PopModalAsync();
            })
        };
        stackLayout.Add(button);
        modalPage.Content = stackLayout;
        await navigation.PushModalAsync(modalPage);
    }
}
