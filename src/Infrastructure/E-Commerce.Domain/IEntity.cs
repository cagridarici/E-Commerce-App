using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain
{
    public interface IEntity
    {

    }

    /// <summary>
    /// Can be used in cases where the id type must be different
    /// </summary>
    /// <typeparam name="T"> Generic Id Type </typeparam>
    public interface IEntity<T> : IEntity
    {

    }
}
