using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHA.ManagementAssistant.Nutritious.Core.Repository.Base
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetByID(int id);
        Task<T> GetByIDAsync(int id);
        bool Create(T Entity);
        bool Update(T Entity);
        bool Delete(T Entity);
        IQueryable<T> GetAll(bool? isDeleted = false);
        IQueryable<T> ForJoin(bool? isDeleted = false);
        bool AddRange(IEnumerable<T> entities);
        //bool RemoveRange(IEnumerable<T> entities);
    }
}
