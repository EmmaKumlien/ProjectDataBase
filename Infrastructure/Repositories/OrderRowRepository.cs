using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class OrderRowRepository(DataContext context) : BaseRepository<OrderRowsEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<OrderRowsEntity> GetAll()
    {
        try
        {
            return _context.OrderRows.Include(x => x.OrderId).Include(x => x.Products).Include(x => x.OrderService.Customer).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override OrderRowsEntity GetOne(Expression<Func<OrderRowsEntity, bool>> predicate)
    {
        try
        {
            return _context.OrderRows.Include(x => x.OrderId).Include(x => x.Products).Include(x=> x.OrderService.Customer).FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override OrderRowsEntity Update(Expression<Func<OrderRowsEntity, bool>> predicate, OrderRowsEntity entity)
    {
        try
        {
            var entityToUpdate = _context.OrderRows.FirstOrDefault(x => x.OrderId == entity.Id);
            if (entityToUpdate != null)
            {

                _context.OrderRows.Entry(entityToUpdate).CurrentValues.SetValues(entity);
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
