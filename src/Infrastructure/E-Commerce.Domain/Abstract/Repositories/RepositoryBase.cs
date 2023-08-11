using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Abstract.Repositories
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepository<TDbContext, TEntity>, IDisposable
      where TEntity : class, IEntity
      where TDbContext : DbContext, new()
    {
        TDbContext _DbContext = null;
        public RepositoryBase()
        {
            _DbContext = new TDbContext();
        }

        public virtual DbSet<TEntity> DbSet
        {
            get
            {
                return _DbContext.Set<TEntity>();
            }
        }

        public virtual TDbContext DbContext
        {
            get
            {
                return _DbContext;
            }
        }

        public virtual IDbConnection GetDbConnection
        {
            get
            {
                return _DbContext.Database.GetDbConnection();
            }
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _DbContext.Remove(entity);
            await _DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = GetItemAsync(id);
            if (entity == null)
                return;
            _DbContext.Remove(entity);
            await _DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> GetCountAsync()
        {
            return await DbSet.CountAsync();
        }

        public virtual TDbContext GetDbContext()
        {
            return _DbContext;
        }

        public virtual async Task<TEntity> GetItemAsync(int id)
        {
            var entity = await _DbContext.Set<TEntity>().FindAsync(new object[] { id });
            return entity;
        }

        public virtual async Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _DbContext.Set<TEntity>().FindAsync(predicate);
            return entity;
        }

        public virtual async Task<List<TEntity>> GetItemsAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual IQueryable<TEntity> GetItemsQuaryable()
        {
            return DbSet;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _DbContext.Attach(entity);
            _DbContext.Update(entity);
            await _DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _DbContext != null)
            {
                _DbContext.Dispose();
                _DbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
