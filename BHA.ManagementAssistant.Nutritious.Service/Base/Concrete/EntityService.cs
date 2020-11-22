using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Core.Service.Interface;

namespace BHA.ManagementAssistant.Nutritious.Core.Service.Concrete
{
    public abstract class EntityService<T> : IEntityService<T> where T : class, IEntity
    {
        public EntityService(IRepository<T> repository)
        {
            this.Repository = repository;
        }

        public IRepository<T> Repository { get; }

        public T Create(T entity, bool commit = false)
        {
            this.Repository.Create(entity);

            if (commit)
            {
                this.Repository.Commit();
            }

            return entity;
        }

        public bool Delete(T entity, bool commit = false)
        {
            bool isOK = this.Repository.Delete(entity);

            if (commit)
            {
                this.Repository.Commit();
            }

            return isOK;
        }

        public T Update(T entity, bool commit = false)
        {
            this.Repository.Update(entity);

            if (commit)
            {
                this.Repository.Commit();
            }

            return entity;
        }
    }
}
