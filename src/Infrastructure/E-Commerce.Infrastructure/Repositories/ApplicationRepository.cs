using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data;
using E_Commerce.Domain.Abstract.Repositories;

namespace E_Commerce.Infrastructure.Repositories
{
    public class ApplicationRepository<TEntity> : RepositoryBase<ApplicationDbContext, TEntity>
        where TEntity : class, IEntity
    {
        // Custom Repository Operations here...
    }
}
