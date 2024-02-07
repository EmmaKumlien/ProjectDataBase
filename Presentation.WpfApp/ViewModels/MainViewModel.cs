using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using Infrastructure.Services;

namespace Presentation.WpfApp.ViewModels;

partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ProductDTO _product = new ProductDTO();

    [ObservableProperty]
    private ProductService _productService;

    [RelayCommand]
    public void AddCosutmer()
    {
        if (!string.IsNullOrWhiteSpace(_product.ArticleNumber)&& !string.IsNullOrWhiteSpace(_product.Title))
        {
            
            _productService.CreateProduct(_product);
            _product = new ProductDTO();
        }
    }

    [RelayCommand]
    public void RemoveCosutmer()
    {
        if (string.IsNullOrWhiteSpace(_product.ArticleNumber))
        _productService.DeleteProduct(_product);
    }

}
