using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WpfApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;
    
    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = _serviceProvider.GetRequiredService<MainMenuWindowViewModel>();
    }






    //[ObservableProperty]
    //private ProductService _productService;

    //[RelayCommand]
    //public void AddCosutmer()
    //{
    //    if (!string.IsNullOrWhiteSpace(_product.ArticleNumber)&& !string.IsNullOrWhiteSpace(_product.Title))
    //    {

    //        _productService.CreateProduct(_product);
    //        _product = new ProductDTO();
    //    }
    //}

    //[RelayCommand]
    //public void RemoveCosutmer()
    //{
    //    if (string.IsNullOrWhiteSpace(_product.ArticleNumber))
    //    _productService.DeleteProduct(_product);
    //}

}
