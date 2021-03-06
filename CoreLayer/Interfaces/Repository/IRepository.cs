using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task Add(T item);
        void Update(T item);
        void Delete(T item);
        Task Save();
    }
}
