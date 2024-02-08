using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Presentation.WpfApp.ViewModels;

public partial class AddProductViewModel :ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ProductService _productService;
   

    public AddProductViewModel(IServiceProvider serviceProvider, ProductService productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
    }
    [RelayCommand]
    private void AddProduct(ProductDTO product)
    {
        var result = _productService.CreateProduct(new ProductDTO{
            ArticleNumber = product.ArticleNumber,
            Title = Console.ReadLine()!,
            Description = Console.ReadLine()!,
            Price = decimal.Parse(Console.ReadLine()!),
            CategoryName = Console.ReadLine()!,
            ManufacturerName = Console.ReadLine()!,

            

        });
        if (result)
            MessageBox.Show("Lyckades");
        else
            MessageBox.Show("Något gick fel");

        var AddProduct = _serviceProvider.GetRequiredService<MainViewModel>();
        AddProduct.CurrentViewModel= _serviceProvider.GetRequiredService<MainMenuWindowViewModel>();
        

    }

    [RelayCommand]
    
    private void NavigateBack()
    {
        var mainView = _serviceProvider.GetRequiredService<MainViewModel>();
        mainView.CurrentViewModel = _serviceProvider.GetRequiredService<MainMenuWindowViewModel>();
    }


}
