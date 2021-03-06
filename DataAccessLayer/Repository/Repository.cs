using CoreLayer.Interfaces.Repository;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        private DbSet<T> _entity;
        private IQueryable<T> _query;
        public Repository(ApplicationContext context, DbSet<T> entity)
        {
            _context = context;
            _entity = entity;
            ClearQuery();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await GetQuery().ToArrayAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await GetQuery().Where(predicate).ToArrayAsync();
        }

        public async Task Add(T item)
        {
            await _entity.AddAsync(item);
        }

        public void Update(T item)
        {
            _context.Update(item);
        }

        public void Delete(T item)
        {
            _context.Remove(item);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        protected IQueryable<T> GetQuery()
        {
            if (_query != null) return _query;
            return _entity.AsQueryable();
        }

        protected void SetQuery(IQueryable<T> query)
        {
            _query = query;
        }

        protected void ClearQuery()
        {
            _query = null;
        }
    }
}
