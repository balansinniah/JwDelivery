using System.Collections.Generic;

namespace EntityFramework.Core.Generic.Pattern.Service
{
    public interface IEntityService<T> : IService
        where T : IEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IAsyncEnumerable<T> GetAll();
        void Update(T entity);
    }
}
