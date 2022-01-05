using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApp.Common.Exceptions;
using WebApp.Domain.Models;

namespace WebApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            var x = _context.Set<T>().Add(entity);
            return x.Entity;
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Item x = new Item();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
        public T GetById(int id)
        {
            var result = _context.Set<T>().Find(id);
            if (result == null)
            {
                throw new NotFoundException("Data doesn't exist", "404");
            }
            return result;

        }
        public T Update( T entity)
        {
            //var res = _context.Set<T>().AsNoTracking().;
            //if (res == null)
            //{
            //    throw new NotFoundException("Data doesn't exist", "404");
            //}
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
        public bool Remove(int id)
        {
            var ent = _context.Set<T>().Find(id);
            if (ent == null)
            {
                throw new NotFoundException("Data doesn't exist", "404");
            }
            _context.Set<T>().Remove(ent);
            return true;
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
