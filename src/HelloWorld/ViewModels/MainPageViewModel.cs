

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HelloWorld.Models;
using HelloWorld.Services;
using System.Collections.ObjectModel;

namespace HelloWorld.ViewModels;

//ViewModel 必须继承ObservableObject
public partial class MainPageViewModel : ObservableObject, IViewModel
{


    private readonly IPoetryStorage _poetryStorage;

    public MainPageViewModel(IPoetryStorage poetryStorage)
    {
        _poetryStorage = poetryStorage;
    }

    [ObservableProperty]
    private ObservableCollection<Poetry> _poetries = new ObservableCollection<Poetry>();

    //public ObservableCollection<Poetry> Poetries { get; } = new();
    //public List<Poetry> Poetry1 = new List<Poetry>();

    [RelayCommand]
    public async Task List()
    {
        var list = await _poetryStorage.GetAllAsync();
        //Poetries.Clear();
        foreach (var item in list)
        {
            Poetries.Add(item);
        }


    }

    [RelayCommand]
    public async Task Add()
    {
        await _poetryStorage.AddAsync(new Poetry
        {
            Content = "Content",
            Title = "Title"
        });
    }

    [RelayCommand]
    public async Task Remove(Poetry poetry)
    {
        await _poetryStorage.RemoveAsync(poetry);
    }

    [RelayCommand]
    public async Task Initialize()
    {
        await _poetryStorage.InitializeAsync();
    }
    //[ObservableProperty]
    //private string _result = string.Empty;

    //public MainPageViewModel()
    //{

    //    ClickMeCommand ??= new RelayCommand(() => Result = "Hello World");
    //}

    //public string Result
    //{
    //    get => _result;
    //    set => SetProperty(ref _result, value);
    //}

    //private const string Key = "m:p:v:m";

    ////public ICommand ClickMeCommand { get; }
    //[RelayCommand]
    //public void Read()
    //{
    //    Result = _keyValueStorage.Get(Key, string.Empty);
    //}

    //[RelayCommand]
    //public void Write()
    //{
    //    _keyValueStorage.Set(Key, Result);
    //    Result = string.Empty;
    //}

    //[RelayCommand]
    //public void ClickMe()
    //{
    //    Result = "Hello World";
    //}
}


public interface IViewModel
{

}
