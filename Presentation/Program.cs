using Infrastructure.Context;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentation.Services;
using System.ComponentModel.Design;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\SQL\ProjectDataBase\Infrastructure\Data\DataBase.mdf;Integrated Security=True;Connect Timeout=30"));


    services.AddScoped<BillingAdressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ContactInformationRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ManufacturerRepository>();
    services.AddScoped<OrderRowRepository>();
    services.AddScoped<OrderServiceRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ProductDTO>();
    services.AddScoped<ProductEntity>();

    services.AddScoped<ProductService>();

    services.AddSingleton<MenuService>();
    


}).Build();
builder.Start();

Console.ReadKey();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMenu();


//var result = productService.CreateProduct(new ProductDTO
//{
//    ArticleNumber = "A4",
//    Title = "Title 4",
//    Description = "",
//    Price = 100,
//    CategoryName = "Category 4",
//    ManufacturerName = "Manufacturer 4",

//});
//if (result)
//    Console.WriteLine("Lyckades");
//else
//    Console.WriteLine("Något gick fel");
//Console.ReadKey();

//var getAll= productService.GetAllProducts().ToList();
//if (getAll != null)
//    foreach (var item in getAll)
//    Console.WriteLine($"{item.ArticleNumber}");
//else
//    Console.WriteLine("Inget i listan");
//Console.ReadKey();
//Console.Clear();

//var getOneProduct = productService.GetAllProducts().FirstOrDefault(x=> x.ArticleNumber == "A2");
//if (getOneProduct != null)
//Console.WriteLine($"{getOneProduct.ArticleNumber}");
//else
//    Console.WriteLine("Hittade ej produkt");
//Console.ReadKey();
//Console.Clear();

////var product = builder.Services.GetRequiredService<ProductRepository>();
//var OldProduct = productService.GetAllProducts().FirstOrDefault(x => x.ArticleNumber == "A2");
//var updateproduct = productService.UpdateProduct(OldProduct!, new ProductEntity
//{
//    ArticleNumber = "A5",
//    Title = "Title 5",
//    Description = "",
//    Price = 100,
//    CategoryId = 4,
//    ManufacturerId = 4
//});

//if (updateproduct != null)
//{
//    Console.WriteLine($"{updateproduct.ArticleNumber}");
//}

//else
//    Console.WriteLine("Något gick fel");

//Console.Clear();



//var category = builder.Services.GetRequiredService<CategoryRepository>();
//var OldCategory = category.GetAll().FirstOrDefault(x => x.CategoryName == "Category 6");
//if (OldCategory == null)
//{
//    var newCategory = new CategoryEntity { CategoryName = "Category 6" };
//    category.Create(newCategory);
//}

//else
//{

//    var updateCategory = category.Update((x => x.CategoryName == "Category 6"),new CategoryEntity
//    {
//        Id = 10,
//        CategoryName = "Category x"
//    });
//}

//Console.ReadKey();
