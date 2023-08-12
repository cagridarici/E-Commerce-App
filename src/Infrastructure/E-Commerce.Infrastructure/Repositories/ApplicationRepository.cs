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
    // Entity'ler icin Genel Operasyonlar bu Generic Class uzerinden tanimlanabilir.
    public class ApplicationRepository<TEntity> : RepositoryBase<ApplicationDbContext, TEntity>
        where TEntity : class, IEntity
    {

    }
}
