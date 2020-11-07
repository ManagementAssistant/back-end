using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BHA.ManagementAssistant.Nutritious.Repository.Base
{
    partial class RepositoryBase<T>
    {
        private IQueryable<T> GetQuery(bool forJoin, bool isDeleted)
        {
            return CreateQuery(forJoin, isDeleted);
        }

        private IQueryable<T> CreateQuery(bool forJoin, bool isDeleted)
        {
            return GetFilterForEntityType(_dbSet.AsQueryable(), isDeleted);
        }

        private IQueryable<T> GetFilterForEntityType(IQueryable<T> query, bool? isDeleted)
        {
            if (!typeof(T).IsAssignableFrom(typeof(IDeletableEntity)) && isDeleted.HasValue)
            {
                query = ((IQueryable<IDeletableEntity>)query).Where<IDeletableEntity>(q => q.isDeleted == isDeleted).Cast<T>();
            }

            return query;
        }
    }
}
