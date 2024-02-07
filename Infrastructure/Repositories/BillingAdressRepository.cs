using Infrastructure.Context;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BillingAdressRepository(DataContext context) : BaseRepository<BillingAdressEntity>(context)
{
    private readonly DataContext _context = context;


}
