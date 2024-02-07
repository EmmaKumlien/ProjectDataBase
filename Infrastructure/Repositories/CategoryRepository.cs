using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Services;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CategoryRepository(DataContext context) : BaseRepository<CategoryEntity>(context)
{
   
    private readonly DataContext _context = context;

    public override CategoryEntity Update(Expression<Func<CategoryEntity, bool>> predicate, CategoryEntity entity)
    {
        try
        {

            var updatedEntity = _context.Categories.FirstOrDefault(x => x.Id == entity.Id);

            if (updatedEntity != null)
            {

                _context.Categories.Entry(updatedEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entity;


            }
            else if (updatedEntity == null)
            {

                _context.Add(entity);
                _context.SaveChanges();

            }


        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }
}
