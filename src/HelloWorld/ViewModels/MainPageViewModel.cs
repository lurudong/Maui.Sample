

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloWorld.ViewModels;

//ViewModel 必须继承ObservableObject
public partial class MainPageViewModel : ObservableObject, IViewModel
{

    [ObservableProperty]
    private string _result = string.Empty;

    //public MainPageViewModel()
    //{

    //    ClickMeCommand ??= new RelayCommand(() => Result = "Hello World");
    //}

    //public string Result
    //{
    //    get => _result;
    //    set => SetProperty(ref _result, value);
    //}


    //public ICommand ClickMeCommand { get; }

    [RelayCommand]
    public void ClickMe()
    {
        Result = "Hello World";
    }
}


public interface IViewModel
{

}
