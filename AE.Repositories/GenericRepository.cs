using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AE.Models.Data;
using AE.Models.Models;
using System;
using System.Linq.Expressions;
using AE.Repositories.Base;

namespace AE.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext context;
        internal Microsoft.EntityFrameworkCore.DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this._logger = logger;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> Add(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Update(T entity)
        {
            var result = dbSet.Update(entity);
            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}
