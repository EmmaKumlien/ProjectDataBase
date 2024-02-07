using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class OrderServiceRepository(DataContext context) : BaseRepository<OrderServiceEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<OrderServiceEntity> GetAll()
    {
        try
        {
            return _context.OrderServices.Include(x => x.Customer).Include(x => x.Id).Include(x => x.OrderRows).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override OrderServiceEntity GetOne(Expression<Func<OrderServiceEntity, bool>> predicate)
    {
        try
        {
            return _context.OrderServices.Include(x => x.Customer).Include(x => x.Id).Include(x => x.OrderRows).FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override OrderServiceEntity Update(Expression<Func<OrderServiceEntity, bool>> predicate, OrderServiceEntity entity)
    {

        try
        {
            var entityToUpdate = _context.OrderServices.FirstOrDefault(x => x.Customer == entity.Customer);
            if (entityToUpdate != null)
            {

                _context.OrderServices.Entry(entityToUpdate).CurrentValues.SetValues(entity);
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
