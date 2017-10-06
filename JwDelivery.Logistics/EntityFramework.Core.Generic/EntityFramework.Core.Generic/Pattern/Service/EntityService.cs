using EntityFramework.Core.Generic.Pattern.Repository;
using System;
using System.Collections.Generic;

namespace EntityFramework.Core.Generic.Pattern.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IAsyncEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
