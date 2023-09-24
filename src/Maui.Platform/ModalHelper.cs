namespace Maui.Platform;

public class ModalHelper
{
    public static async Task ShowModalAsync(INavigation navigation, string title, params IView[] views)
    {
        var modalPage = new ContentPage();
        modalPage.Title = title;
        var stackLayout = new StackLayout()
        {
            Margin = 20

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

    public static async Task ShowScrollViewModalAsync(INavigation navigation, string title, params IView[] views)
    {
        var modalPage = new ContentPage();
        modalPage.Title = title;
        var scrollView = new ScrollView()
        {
            Margin = 20

        };

        StackLayout stackLayout = new StackLayout()
        {

            Spacing = 10
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
        scrollView.Content = stackLayout;
        modalPage.Content = scrollView;
        await navigation.PushModalAsync(modalPage);
    }
}
