using Infrastructure.Dtos;
using Infrastructure.Services;
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
        private readonly ProductService _productService;
       

        public MainWindow(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;

                       
        }

        private void CreateDemoProduct()
        {
            var result = _productService.CreateProduct(new ProductDTO
            {
                ArticleNumber = "A10",
                Title = "Title 10",
                Description = "",
                Price = 100,
                CategoryName = "Category 1",
                ManufacturerName = "Manufacturer 3",

            });
            if (result)
                MessageBox.Show("Lyckades!");
            else
                MessageBox.Show("Något gick fel");
        }

      

        //private void BtnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    var result = _productService.CreateProduct(new ProductDTO
        //    {
        //        ArticleNumber = product.ArticleNumber,
        //        Title = product.Title,
        //        Description = product.Description,
        //        Price = product.Price,
        //        CategoryName = product.CategoryName,
        //        ManufacturerName = product.ManufacturerName,

        //    });
        //    if (result)
        //        MessageBox.Show("Lyckades!");
        //    else
        //        MessageBox.Show("Något gick fel");
        //}

       

        private void BtnAddMenu_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow.GetWindow(this).Show();
        }

        private void BtnViewOneMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpdateMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            _productService.GetAllProducts();
            
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}