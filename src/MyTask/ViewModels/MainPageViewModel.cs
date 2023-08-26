using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTask.ViewModels;

public sealed partial class MainPageViewModel : ObservableObject
{

    public MainPageViewModel()

    {
        Items = new ObservableCollection<string>();
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
    public void Add()
    {
        if (string.IsNullOrWhiteSpace(Text) || Items.Contains(Text))
        {

            return;

        }

        Items.Add(Text);
        this.Text = string.Empty;
    }

    [RelayCommand]
    public void Delete(string text)
    {

        if (string.IsNullOrEmpty(text) || !Items.Contains(text))
        {
            return;
        }
        Items.Remove(text);
    }


}
