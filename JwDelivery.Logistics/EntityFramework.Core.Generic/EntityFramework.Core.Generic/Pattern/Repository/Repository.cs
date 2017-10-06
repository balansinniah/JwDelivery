using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFramework.Core.Generic.Pattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected IDbContext Entities;
        protected readonly DbSet<T> Dbset;
        public Repository(IDbContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        public async Task<EntityEntry<T>> Add(T entity)
        {
            return await Dbset.AddAsync(entity);
        }

        public EntityEntry<T> Delete(T entity)
        {
            return Dbset.Remove(entity);
        }
        public void DeleteAll(IEnumerable<T> entities)
        {
            Dbset.RemoveRange(entities);
        }
        public void Edit(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public IAsyncEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = Dbset.Where(predicate).AsAsyncEnumerable();
            return query;
        }
        public async Task<T> Find(long id)
        {
           return  await Dbset.FindAsync(id);
        }
        public IAsyncEnumerable<T> GetAll()
        {
            return Dbset.AsAsyncEnumerable();
        }

        public async Task<int> Save()
        {
            return await Entities.SaveChangesAsync();
        }
    }
}
