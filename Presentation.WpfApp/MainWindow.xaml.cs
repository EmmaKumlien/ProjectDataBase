using Infrastructure.Dtos;
using Infrastructure.Services;
using Presentation.WpfApp.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.WpfApp
{

    public partial class MainWindow : Window
    {
       // private readonly ProductService _productService;


        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;


        }

        //private void CreateDemoProduct()
        //{
        //    var result = _productService.CreateProduct(new ProductDTO
        //    {
        //        ArticleNumber = "A10",
        //        Title = "Title 10",
        //        Description = "",
        //        Price = 100,
        //        CategoryName = "Category 1",
        //        ManufacturerName = "Manufacturer 3",

        //    });
        //    if (result)
        //        MessageBox.Show("Lyckades!");
        //    else
        //        MessageBox.Show("Något gick fel");
        //}

    }
}