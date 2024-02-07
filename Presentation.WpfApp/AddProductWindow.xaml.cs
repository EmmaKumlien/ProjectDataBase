using Infrastructure.Dtos;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation.WpfApp
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private readonly ProductDTO _product = new ProductDTO();
        private readonly ProductService _productService;
        public AddProductWindow(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddArticleNumber.Text))
            {
                var input = new ProductDTO 
                { 
                    ArticleNumber = AddArticleNumber.Text,
                    Title = AddTitle.Text,
                    Description = AddDescription.Text,
                    Price = decimal.Parse(AddPrice.Text),
                    CategoryName = AddCategoryName.Text,
                    ManufacturerName = AddManufacturerName.Text,    
                                       
                
                };
                var result = _productService.CreateProduct(input);
            }

        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
