using CommunityToolkit.Mvvm.ComponentModel;

namespace MyTask.ViewModels;

[QueryProperty("Text", "Text")]
public sealed partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string _text;
}