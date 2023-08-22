using HelloWorld.ViewModels;

namespace HelloWorld;

public sealed class ServiceLocator
{

    private IServiceProvider _serviceProvider;

    public MainPageViewModel MainPageViewModel => _serviceProvider.GetService<MainPageViewModel>();

    public ServiceLocator()
    {

        _serviceProvider = new ServiceCollection()

            .BuildServiceProvider();
    }
}