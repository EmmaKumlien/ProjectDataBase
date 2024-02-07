using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<CustomerEntity> GetAll()
    {
        try
        {
            return _context.Customers.Include(x => x.ContactInformation).Include(x => x.BillingAdress).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override CustomerEntity GetOne(Expression<Func<CustomerEntity, bool>> predicate)
    {
        try
        {
            return _context.Customers.Include(x => x.ContactInformation).Include(x => x.BillingAdress).FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override CustomerEntity Update(Expression<Func<CustomerEntity, bool>> predicate, CustomerEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Customers.FirstOrDefault(x => x.FirstName == entity.FirstName && x.LastName == entity.LastName);
            if (entityToUpdate != null)
            {

                _context.Customers.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entity;


            }
            else if (entityToUpdate == null)
            {

                _context.Add(entity);
                _context.SaveChanges();

            }


        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }
}
