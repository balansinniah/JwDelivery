using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFramework.Core.Generic.Pattern.Repository
{
    public interface IRepository<T> : IEntity where T: class
    {
        IAsyncEnumerable<T> GetAll();
        IAsyncEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> Find(long id);
        Task<EntityEntry<T>> Add(T entity);
        EntityEntry<T> Delete(T entity);
        void DeleteAll(IEnumerable<T> entities);
        void Edit(T entity);
        Task<int> Save();
    }
}
