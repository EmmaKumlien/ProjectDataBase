using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProductService(CategoryRepository categoryRepository, ProductRepository productRepository, OrderRowRepository orderRowRepository, ManufacturerRepository manufacturerRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ProductRepository _productRepository = productRepository;
    private readonly OrderRowRepository _orderRowRepository = orderRowRepository;
    private readonly ManufacturerRepository _manufacturerRepository = manufacturerRepository;


    public bool CreateProduct(ProductDTO product)
    {
        try
        {
          
            if (!_productRepository.Exists(x => x.ArticleNumber == product.ArticleNumber)) // kollar att artikeln inte existerar
            {
                var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == product.CategoryName); //Skapar en kategori om ej finns
                if (categoryEntity == null)
                {

                    categoryEntity= _categoryRepository.Create(new CategoryEntity { CategoryName = product.CategoryName });
                    
                }
                
                
               
                var manufacturerEntity = _manufacturerRepository.GetOne(x => x.ManufacturerName == product.ManufacturerName);  //Skapar en manufacturer om ej finns
                manufacturerEntity ??= _manufacturerRepository.Create(new ManufacturerEntity
                {
                    ManufacturerName = product.ManufacturerName,
                });

                var productEntity = new ProductEntity
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = categoryEntity.Id,
                    ManufacturerId = manufacturerEntity.Id

                };
                
                var result = _productRepository.Create(productEntity);
                if (result != null)
                {
                    return true;
                }
                
            }

        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        
        return false;
    }
    
    public IEnumerable<ProductDTO> GetAllProducts()
    {
        var products = new List<ProductDTO>();
        try
        {
            var result = _productRepository.GetAll();
            foreach(var item in result)
            {
                products.Add(new ProductDTO
                {
                    ArticleNumber = item.ArticleNumber,
                    Title = item.Title,
                    Description = item.Description,
                    Price = item.Price,
                    CategoryName = item.Category.CategoryName,
                    ManufacturerName = item.Manufacturer.ManufacturerName
                });
                
            }
        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return products;
    }

    public ProductEntity GetOneProduct(ProductEntity product)
    {
        try
        {
            var result = _productRepository.GetOne(x => x.ArticleNumber == product.ArticleNumber);
            if (result != null)
            return product;
        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return null!;
    }
    public ProductEntity UpdateProduct(ProductDTO product, ProductEntity entity)
    {
        try
        {
            var productExists = _productRepository.Exists(x => x.ArticleNumber == product.ArticleNumber);
            if (productExists == true)
            {
                var updateCategory = _categoryRepository.GetOne(x=> x.CategoryName == product.CategoryName);
                if (updateCategory == null)
                {
                    _categoryRepository.Create(entity.Category);
                }
                var updatedManufacturer = _manufacturerRepository.GetOne(x=> x.ManufacturerName == product.ManufacturerName);
                if (updatedManufacturer == null)
                    _manufacturerRepository.Create(entity.Manufacturer);

                var result = _productRepository.Update((x => x.ArticleNumber == product.ArticleNumber), new ProductEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    Title = entity.Title,
                    Description = entity.Description,
                    Price = entity.Price,
                    CategoryId =   entity.CategoryId,
                    ManufacturerId = entity.ManufacturerId
                });

                return entity;
            }
            else if (productExists == false)
            {
                var newProduct = _productRepository.Create(entity);
            }

        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return null!;
    }

    public bool DeleteProduct(ProductDTO product)
    {
        try
        {
            var result = _productRepository.Delete(x => x.ArticleNumber == product.ArticleNumber);
            if (result)
            {
                
                Console.WriteLine("Deleted");
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return false;


    }

    public OrderRowsEntity UpdateOrder (OrderRowsEntity order)
    {
        try
        {
            var orderExists = _orderRowRepository.Exists(x => x.Id == order.Id);
            if (orderExists == true)
            {
                var updateOrder = _orderRowRepository.GetOne(x => x.Id == order.Id);
                if (updateOrder == null)
                {
                    updateOrder = order;
                    _orderRowRepository.Create(updateOrder);
                    
                }
                

                var result = _orderRowRepository.Update((x => x.Id == order.Id), new OrderRowsEntity
                {
                    Quatity = order.Quatity,
                    Price = order.Price,
                    ProductId = order.ProductId,
                    Products = order.Products,
                    OrderId = order.OrderId,
                    OrderService = order.OrderService,
                    
                });

                return updateOrder;
            }
            else if (orderExists == false)
            {
                var newProduct = _orderRowRepository.Create(order);
            }

        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return null!;
    }

}

