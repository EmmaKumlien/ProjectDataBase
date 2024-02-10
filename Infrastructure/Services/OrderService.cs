using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Infrastructure.Services;

internal class OrderService
{
    private readonly CustomerRepository _customerRepository;
    private readonly ProductRepository _productRepository;
    private readonly OrderRowRepository _orderRowRepository;
    private readonly OrderServiceRepository _orderServiceRepository;

    public OrderService(CustomerRepository customer, ProductRepository product, OrderRowRepository orderRowRepository, OrderServiceRepository orderServiceRepository)
    {
        _customerRepository = customer;
        _productRepository = product;
        _orderRowRepository = orderRowRepository;
        _orderServiceRepository = orderServiceRepository;
    }

    public bool CreateOrder(OrderDTO order)
    {
        var customer = new CustomerEntity();
        var product = new ProductEntity();
        var orders = new OrderServiceEntity();
        try
        {

            if (!_orderRowRepository.Exists(x => x.OrderId == order.Id)) // kollar att ordern inte existerar
            {
                var customerEntity = _customerRepository.GetOne(x => x.Id == order.Customer.Id); //Skapar en kund om ej finns
                if (customerEntity == null)
                {

                    customerEntity = _customerRepository.Create(new CustomerEntity
                    { 
                        Id = order.Id,
                        FirstName = order.Customer.FirstName,
                        LastName = order.Customer.LastName,
                        BillingAdress = (new BillingAdressEntity 
                        {
                            Id = order.Customer.BillingAdress.Id, 
                            StreetName = order.Customer.BillingAdress.StreetName,
                            PostalCode = order.Customer.BillingAdress.PostalCode,
                            City = order.Customer.BillingAdress.City,
                        }),
                        ContactInformation = order.Customer.ContactInformation,
                                          
                    
                    });

                }


                var orderEntity = new OrderRowsEntity
                {
                    Id = order.Id,
                    Quatity = order.Quatity,
                    Price = order.Price,
                    ProductId = orders.OrderRows.First().ProductId,
                    Products = orders.OrderRows.First().Products,
                    OrderId = orders.Id,
                    OrderService = orders.OrderRows.First().OrderService,
                     

                    

                };

                var result = _orderRowRepository.Create(orderEntity);
                if (result != null)
                {
                    return true;
                }

            }

        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }

        return false;
    }

    public IEnumerable<OrderDTO> GetAllOrders(OrderDTO order)
    {
        var listOfOrders = new List<OrderDTO>();
        try
        {
            var result = _orderRowRepository.GetAll();
            foreach (var item in result)
            {
                listOfOrders.Add(new OrderDTO
                {
                    Id = item.Id,
                    Quatity = item.Quatity,
                    Price = item.Price,
                    Customer = order.Customer,
                    Product = order.Product

                    
                });

            }
        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return listOfOrders;
    }

    public OrderRowsEntity GetOneProduct(OrderRowsEntity order)
    {
        try
        {
            var result = _orderRowRepository.GetOne(x => x.Id == order.Id);
            if (result != null)
                return order;
        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return null!;
    }
    public OrderRowsEntity UpdateOrder(OrderDTO order, OrderRowsEntity entity, CustomerEntity customer)
    {
       
        try
        {
            var orderExists = _orderRowRepository.Exists(x => x.Id == order.Id);
            if (orderExists == true)
            {
                var updateCustomer = _customerRepository.GetOne(x => x.Id == customer.Id);
                if (updateCustomer == null)
                {
                    _customerRepository.Create(customer);
                }
                
                var result = _orderRowRepository.Update((x => x.Id == order.Id), new OrderRowsEntity
                {
                    Id = entity.Id,
                    Quatity = entity.Quatity,
                    Price = entity.Price,
                    ProductId = entity.ProductId,
                    Products = entity.Products,
                    OrderId = order.Id,
                    OrderService = entity.OrderService,

                });

                return entity;
            }
            else if (orderExists == false)
            {
                var newOrder = _orderRowRepository.Create(entity);
            }

        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return null!;
    }

    public bool DeleteOrder(OrderDTO order)
    {
        try
        {
            var result = _orderRowRepository.Delete(x => x.Id == order.Id);
            if (result)
            {

                Console.WriteLine("Deleted");
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("##Error## : " + ex.Message); }
        return false;


    }


}


