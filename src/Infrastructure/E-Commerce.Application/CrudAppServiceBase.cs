using E_Commerce.Domain;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    public abstract class CrudAppServiceBase <TEntity> : IApplicationService, IDisposable
        where TEntity: class, IEntity, new()
    {
        private ApplicationRepository<TEntity> _Repository = null; 

        public CrudAppServiceBase(ApplicationRepository<TEntity> applicationRepository)
        {
            _Repository = applicationRepository;
        }

        public async Task<OperationResult<List<TEntity>>> GetItems()
        {
            var result = new OperationResult<List<TEntity>>();
            try
            {
                result.SetValue(await _Repository.GetItemsAsync());
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public OperationResult<IQueryable<TEntity>> GetItemsQueryable()
        {
            var result = new OperationResult<IQueryable<TEntity>>();
            try
            {
                result.SetValue(_Repository.GetItemsQuaryable());
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public async Task<OperationResult> DeleteItem(TEntity entity)
        {
            var result = new OperationResult();
            try
            {
                await _Repository.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public async Task<OperationResult> DeleteItem(int id)
        {
            var result = new OperationResult();
            try
            {
                await _Repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public async Task<OperationResult<int>> GetCount()
        {
            var result = new OperationResult<int>();
            try
            {
                result.SetValue(await _Repository.GetCountAsync());
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public async Task<OperationResult<TEntity>> GetItem(int id)
        {
            var result = new OperationResult<TEntity>();
            try
            {
                result.SetValue(await _Repository.GetItemAsync(id));
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public async Task<OperationResult> InsertItem(TEntity entity)
        {
            var result = new OperationResult();
            try
            {
                await _Repository.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }


        public async Task<OperationResult> UpdateItem(TEntity entity)
        {
            var result = new OperationResult();
            try
            {
                await _Repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _Repository != null)
            {
                _Repository.Dispose();
                _Repository = null;
            }
            GC.SuppressFinalize(this);
        }

        //public OperationResult<T> Execute<T>(Action<OperationResult<T>> action)
        //{
        //    var result = new OperationResult<T>();
        //    try
        //    {
        //        action(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetError(ex);
        //    }
        //    return result;
        //}
    }
}
