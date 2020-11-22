using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;

namespace BHA.ManagementAssistant.Nutritious.Core.Service.Interface
{
    public interface IEntityService<T> where T : class, IEntity
    {
        IRepository<T> Repository { get; }
        T Create(T entity, bool commit = false);
        T Update(T entity, bool commit = false);
        bool Delete(T entity, bool commit = false);
    }
}
