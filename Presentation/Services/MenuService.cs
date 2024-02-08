using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;

namespace Presentation.Services;

public class MenuService
{

    private readonly ProductService _productService;
    private readonly ProductDTO _product;
    private readonly ProductRepository _productRepository;
    private readonly ProductEntity _entity = new ProductEntity();

    public MenuService(ProductService productService, ProductRepository productRepository, ProductEntity entity, ProductDTO product)
    {
        _productService = productService;

        _productRepository = productRepository;
        _entity = entity;
        _product = product;
    }

    internal void TitleMenu(string Title)
    {
        Console.Clear();
        Console.WriteLine($"###{Title}###");
        Console.WriteLine("");
    }

    internal void PressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press Any key to continue!");
        Console.ReadKey();
    }

    public void ShowMenu()
    {
        TitleMenu("MainMenu");
        while (true)
        {
            TitleMenu("Main Menu");
            Console.WriteLine($"{"1.",-3}Add new product.");
            Console.WriteLine($"{"2.",-3}Remove product from list.");
            Console.WriteLine($"{"3.",-3}Show one product from list.");
            Console.WriteLine($"{"4.",-3}Show all product from list.");
            Console.WriteLine($"{"5.",-3}Update product from list.");
            Console.WriteLine($"{"Q.",-3}Exit application.");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddMenu();
                    break;
                case "2":
                    RemoveMenu();
                    break;
                case "3":
                    ShowOneMenu();
                    break;
                case "4":
                    ShowAllMenu();
                    break;
                case "5":
                    UpdateMenu();
                    break;
                case "q" or "Q":
                    ExitProgram();
                    break;
            }


        }



    }

    private void AddMenu()
    {
        ProductDTO product = new ProductDTO();


        TitleMenu("Add product to list");         //insamling av data för att lägga till ny product


        Console.WriteLine("Article number:");
        product.ArticleNumber = Console.ReadLine()!;

        Console.WriteLine("\nTitle:");
        product.Title = Console.ReadLine()!;

        Console.WriteLine("\nDescription:");
        product.Description = Console.ReadLine()!;


        Console.WriteLine("\nPrice:");
        product.Price = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("\nCategory Name:");
        product.CategoryName = Console.ReadLine()!;


        Console.WriteLine("\nManufacturer Name:");
        product.ManufacturerName = Console.ReadLine()!;

        var result = _productService.CreateProduct(product);

        PressAnyKey();

    }

    private void RemoveMenu()
    {
        ProductDTO product = new ProductDTO();

        TitleMenu("Remove a product from list");
        Console.Write("Enter ArticleNumber: ");
        product.ArticleNumber = Console.ReadLine()!; //Lagrar input i variabel som kan användas för att skickas till metod
        var result = _productService.DeleteProduct(product); //skickar lista samt input till metod i productService

        if (result)
            Console.WriteLine("Product deleted");
        else
            Console.WriteLine("Something went wrong");



        PressAnyKey();


    }

    private void ShowOneMenu()
    {
        TitleMenu("Find Product");
        Console.Write("Enter ArticleNumber: ");
        _entity.ArticleNumber = Console.ReadLine()!;

        var input = _productRepository.Exists(x=> x.ArticleNumber == _entity.ArticleNumber);
        if (input)
        _productService.GetOneProduct(_entity);

        else
            Console.WriteLine("Something went wrong");

        
        


        PressAnyKey();

    }

    private void ShowAllMenu()
    {
        TitleMenu("Show all products in list");

        var result = _productService.GetAllProducts(_product);
        if (result != null)
        {
          foreach (var item in result)
            {
                Console.WriteLine($"{item.ArticleNumber}" + " " + $"{item.Title}\n{item.Description}\n{item.Price}\n{item.CategoryName}\n{item.ManufacturerName}\n\n");
            }

        }
        if (result == null)
        {
            Console.WriteLine("##No products in list##");
        }

        PressAnyKey();
    }

    private void UpdateMenu()
    {
        ProductDTO product = new ProductDTO();


        TitleMenu("Find Product");
        Console.Write("Enter ArticleNumber: ");
        product.ArticleNumber = Console.ReadLine()!;
        Console.WriteLine("Enter new information:");
        Console.Write("Article Number:");
        _entity.ArticleNumber= Console.ReadLine()!;
        Console.Write("Title:");
        _entity.Title = Console.ReadLine()!;
        Console.Write("Description:");
        _entity.Description = Console.ReadLine()!;
        Console.Write("Price:");
        _entity.Price = decimal.Parse(Console.ReadLine()!);
        Console.Write("Category name:");
        _product.CategoryName = Console.ReadLine()!;
        Console.Write("Mnufacturer name:");
        _product.ManufacturerName = Console.ReadLine()!;

        var input = _productRepository.Exists(x => x.ArticleNumber == product.ArticleNumber);
        if (input)
            _productService.UpdateProduct(product, _entity);

        else
            Console.WriteLine("Something went wrong");
    }

    private void ExitProgram()
    {
        TitleMenu("Exit program");
        Console.WriteLine("Are you sure you want to exit program? y/n");
        var input = Console.ReadLine()!;

        switch (input)
        {
            case "y" or "Y":
                Environment.Exit(0);
                break;

            case "n" or "N":
                ShowMenu();
                break;
        }

        PressAnyKey();
    }
}

