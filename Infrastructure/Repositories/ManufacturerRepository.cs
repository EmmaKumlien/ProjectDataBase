using Infrastructure.Context;
using Infrastructure.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ManufacturerRepository(DataContext context) : BaseRepository<ManufacturerEntity>(context)
{
    private readonly DataContext _context = context;

    public override ManufacturerEntity Update(Expression<Func<ManufacturerEntity, bool>> predicate, ManufacturerEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Manufacturers.FirstOrDefault(x => x.ManufacturerName == entity.ManufacturerName);
            if (entityToUpdate != null)
            {

                _context.Manufacturers.Entry(entityToUpdate).CurrentValues.SetValues(entity);
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
