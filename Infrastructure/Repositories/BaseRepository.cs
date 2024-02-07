using Infrastructure.Context;
using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }

    //Create
    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            var result = _context.Set<TEntity>().AsEnumerable().FirstOrDefault(entity);
            
            if (result != null)
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            


        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:"+ ex.Message); }
        return null!;
    }

    //Read
    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            var result =  _context.Set<TEntity>().ToList();
            if (result != null) 
            { 
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;
    }

    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = _context.Set<TEntity>().FirstOrDefault(predicate);

            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return null!;

    }

    //Update

    // public abstract TEntity Update(TEntity entity);
    public virtual TEntity Update(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().Find(entity);
            if (entityToUpdate != null)
            {
                entityToUpdate = entity;
                _context.Set<TEntity>().Update(entityToUpdate);
                _context.SaveChanges();
               
            }
            return entityToUpdate!;


        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
       return null!;

    }

    //Delete

    public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entityToRemove = _context.Set<TEntity>().FirstOrDefault(predicate);
            if (entityToRemove != null)
            {
                _context.Set<TEntity>().Remove(entityToRemove);
                _context.SaveChanges();
                return true;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return false;

    }

    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = _context.Set<TEntity>().Any(predicate);
            if (result == true)
            {
                return result;
            }

            if (result == false)
            {
                return false;
            }
        }
        catch (Exception ex) { Debug.WriteLine("##ERROR##:" + ex.Message); }
        return false;
    }

}
