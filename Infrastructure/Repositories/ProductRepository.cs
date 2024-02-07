using Infrastructure.Context;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ProductRepository(DataContext context, CategoryRepository categoryRepository, ManufacturerRepository manufacturerRepository) : BaseRepository<ProductEntity>(context)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ManufacturerRepository _manufacturerRepository = manufacturerRepository;
    private readonly DataContext _context = context;

    public override ProductEntity Create(ProductEntity entity)
    {
        try
        {
            var categoryEntity = _context.Categories.Find(entity.CategoryId);
            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(entity.Category);
                //_context.Categories.Add(categoryEntity);
                //_context.SaveChanges();
            }
            
            var manufacturerEntity = _context.Manufacturers.Find(entity.ManufacturerId);
            if (manufacturerEntity == null)
            {
                manufacturerEntity = _manufacturerRepository.Create(new ManufacturerEntity { Id = entity.Manufacturer.Id, ManufacturerName = "NoName" });
            }

            var result = _context.Products.FirstOrDefault(x => x.ArticleNumber == entity.ArticleNumber);

            if (result != null)
            {
                //_context.entity.Add(entity);
                //_context.SaveChanges();
                return entity;


            }
            else if (result == null)
            {
                _context.Products.Add(entity);
                _context.SaveChanges();
                return entity;
            }



        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public CategoryEntity CreateCategory(ProductEntity productEntity)
    {
        try
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == productEntity.CategoryId);
            if (category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category;

            }
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;

    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        try
        {
            return _context.Products.Include(x => x.Category).Include(x => x.Manufacturer).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
        
    }

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            return _context.Products.Include(x => x.Category).Include(x => x.Manufacturer).FirstOrDefault(predicate)!;
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public override ProductEntity Update(Expression<Func<ProductEntity, bool>> predicate, ProductEntity entity)
    {
        
        try
        {
            
            var updatedEntity = _context.Products.FirstOrDefault(x=> x.ArticleNumber == entity.ArticleNumber);
            
            if (updatedEntity != null)
            {
                
                _context.Products.Entry(updatedEntity).CurrentValues.SetValues(entity);
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
