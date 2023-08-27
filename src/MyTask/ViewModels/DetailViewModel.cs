using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyTask.ViewModels;

[QueryProperty("Text", "Text")]
public sealed partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string _text;

    [RelayCommand]
    Task GetBack()
    {
        return Shell.Current.GoToAsync("..");
    }
}