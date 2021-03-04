using Microsoft.EntityFrameworkCore;
using RivTech.WebService.Generic.Data.Context;
using RivTech.WebService.Generic.Data.Entity;
using RivTech.WebService.Generic.DataProvider.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace RivTech.WebService.Generic.DataProvider
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity<byte>
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual bool Exist(object id)
        {
            return _context.Set<T>().Any(a => a.Id == (byte)id);
        }

        public virtual string Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return "Saved";
        }

        public virtual string Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return "Saved";
        }

        public virtual string Remove(object id)
        {
            var entity = _context.Set<T>().Find(id);
            entity.IsActive = false;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return "Deleted";
        }

        public virtual string RemoveRange(T[] entities)
        {
            _context.Set<T>().RemoveRange(entities);
            foreach (var entity in entities)
            {
                entity.IsActive = false;
                _context.Set<T>().Update(entity);
            }
            _context.SaveChanges();
            return "Deleted";
        }

        public virtual T Find(object id, string[] includedProperties = null)
        {
            var setContext = _context.Set<T>().Where(a => a.Id == (byte)id && a.IsActive == true).AsQueryable();
            if (includedProperties != null)
            {
                foreach (var property in includedProperties)
                {
                    setContext = setContext.Include(property);
                }
            }

            return setContext.FirstOrDefault();
        }

        public virtual IEnumerable<T> FindAll(string[] includedProperties = null)
        {
            var setContext = _context.Set<T>().Where(a => a.IsActive == true).AsQueryable();
            if (includedProperties != null)
            {
                foreach (var property in includedProperties)
                {
                    setContext = setContext.Include(property);
                }
            }
            return setContext.ToList();
        }

        public virtual void SaveChanges()
        {
            //Add audit trail data here..
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //Do something like logging
                        break;
                    case EntityState.Modified:
                        //Do something like logging
                        break;
                }
            }
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
        }
    }
}
