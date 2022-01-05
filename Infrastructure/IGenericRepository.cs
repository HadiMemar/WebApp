using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApp.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Update(T entity);
        void AddRange(IEnumerable<T> entities);
        bool Remove(int id);
        void RemoveRange(IEnumerable<T> entities);
    }
}
