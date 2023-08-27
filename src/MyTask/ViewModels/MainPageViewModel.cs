using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTask.ViewModels;

public sealed partial class MainPageViewModel : ObservableObject
{
    IConnectivity _connectivity;
    public MainPageViewModel(IConnectivity connectivity)

    {
        Items = new ObservableCollection<string>();
        _connectivity = connectivity;
    }

    [ObservableProperty]
    private string _text;

    [ObservableProperty]
    private ObservableCollection<string> _items;


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    public async Task Add()
    {

        if (string.IsNullOrWhiteSpace(Text) || Items.Contains(Text))
        {

            return;
        }

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Error", "No Internet Connection", "OK");
            return;
        }

        Items.Add(Text);
        this.Text = string.Empty;
    }

    [RelayCommand]
    async Task Delete(string text)
    {


        if (string.IsNullOrEmpty(text) || !Items.Contains(text))
        {
            return;
        }
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Error", "No Internet Connection", "OK");
            return;
        }
        Items.Remove(text);
    }

    [RelayCommand]
    async Task Tap(string value)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}", new Dictionary<string, object> { { "Text", value } });
    }

}
