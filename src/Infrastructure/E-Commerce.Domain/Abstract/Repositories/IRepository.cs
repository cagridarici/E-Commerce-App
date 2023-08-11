using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Abstract.Repositories
{
    public interface IRepository<TDbContext, TEntity>
     where TEntity : class, IEntity
     where TDbContext : DbContext
    {
        TDbContext GetDbContext();
        DbSet<TEntity> DbSet { get; }
        IDbConnection GetDbConnection { get; }
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetItemsAsync();
        Task<List<TEntity>> GetItemsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> GetCountAsync();
        IQueryable<TEntity> GetItemsQuaryable();
        Task<TEntity> GetItemAsync(int id);
        Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
