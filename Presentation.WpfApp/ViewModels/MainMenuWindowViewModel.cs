

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WpfApp.ViewModels;

public partial class MainMenuWindowViewModel :ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public MainMenuWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [RelayCommand]
    private void NavigateAdd()
    {
        var mainView = _serviceProvider.GetRequiredService<MainViewModel>();
        mainView.CurrentViewModel = _serviceProvider.GetRequiredService<AddProductViewModel>();
    }

    [RelayCommand]
    private void NavigateViewAll()
    {
        var mainView = _serviceProvider.GetRequiredService<MainViewModel>();
        mainView.CurrentViewModel = _serviceProvider.GetRequiredService<ListProductViewModel>();
    }

    [RelayCommand]
    private void NavigateViewOne()
    {
        var mainView = _serviceProvider.GetRequiredService<MainViewModel>();
        mainView.CurrentViewModel = _serviceProvider.GetRequiredService<ViewOneProductViewModel>();
    }

    [RelayCommand]
    private void NavigateUpdate()
    {
        var mainView = _serviceProvider.GetRequiredService<MainViewModel>();
        mainView.CurrentViewModel = _serviceProvider.GetRequiredService<UpdateProductViewModel>();
    }

    [RelayCommand]
    private void NavigateRemove()
    {
        var mainView = _serviceProvider.GetRequiredService<MainViewModel>();
        mainView.CurrentViewModel = _serviceProvider.GetRequiredService<RemoveProductViewModel>();
    }
}
