using Infrastructure.Context;
using Infrastructure.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ContactInformationRepository(DataContext context) : BaseRepository<ContactInformationEntity>(context)
{
    private readonly DataContext _context = context;

    public override ContactInformationEntity Update(Expression<Func<ContactInformationEntity, bool>> predicate, ContactInformationEntity entity)
    {
        try
        {

            var updatedEntity = _context.ContactInformations.FirstOrDefault(x => x.Email == entity.Email);

            if (updatedEntity != null)
            {

                _context.ContactInformations.Entry(updatedEntity).CurrentValues.SetValues(entity);
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

