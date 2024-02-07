using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<CategoryEntity> Categories { get; set; }
    public virtual DbSet<ManufacturerEntity> Manufacturers { get; set; }
    public virtual DbSet<CustomerEntity> Customers { get; set; }
    public virtual DbSet<BillingAdressEntity> BillingAdresses { get; set;}
    public virtual DbSet<ContactInformationEntity> ContactInformations { get; set; }
    public virtual DbSet<OrderServiceEntity> OrderServices { get; set; }
    public virtual DbSet<OrderRowsEntity> OrderRows { get; set; }



}
