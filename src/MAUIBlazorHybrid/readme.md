# Bazor/Maui Tabs 方式
修改```MainPage.xaml```
```C#
<TabbedPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MAUIBlazorHybrid"
             xmlns:pages="clr-namespace:MAUIBlazorHybrid.Pages"
             x:Class="MAUIBlazorHybrid.MainPage"
             BackgroundColor="{DynamicResource PageBackgroundColor}">
    <!--Bazor/Maui Tabs 方式-->
    <ContentPage Title="Index">

        <BlazorWebView   HostPage="wwwroot/index.html">
            <BlazorWebView.RootComponents>
                <RootComponent Selector="#app" ComponentType="{x:Type pages:Index}" />
            </BlazorWebView.RootComponents>
        </BlazorWebView>

    </ContentPage>

    <ContentPage Title="Counter">

        <BlazorWebView  HostPage="wwwroot/index.html">
            <BlazorWebView.RootComponents>
                <RootComponent Selector="#app" ComponentType="{x:Type pages:Counter}" />
            </BlazorWebView.RootComponents>
        </BlazorWebView>

    </ContentPage>

    <ContentPage Title="Maui">

        <Label Text="这里是Maui" TextColor="Black" FontSize="28"></Label>

    </ContentPage>

</TabbedPage>
1.添加 xmlns:pages="clr-namespace:MAUIBlazorHybrid.Pages" 引用
2.BlazorWebView x:Name 也不需要
3.cs类下去掉ContentPage
4.修改ComponentType 
```
https://github.com/hjam40/Camera.MAUI


