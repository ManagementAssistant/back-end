using BHA.ManagementAssistant.Nutritious.Common.Constant;
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
            IQueryable<T> query = _dbSet.AsQueryable();
            return GetFilterForEntityType(query, isDeleted);
        }

        private IQueryable<T> GetFilterForEntityType(IQueryable<T> query, bool? isDeleted)
        {
            if (typeof(T).GetInterface(EntityType.DeletableEntity) != null)
            {
                ApplyDeletedFilters(ref query, isDeleted);
            }

            if (typeof(T).GetInterface(EntityType.OrganizationBasedEntity) != null)
            {
                //ApplyOrganizationFilters(ref query)
            }

            return query;
        }

        private void ApplyOrganizationFilters(IQueryable<T> query)
        {

        }

        private void ApplyDeletedFilters(ref IQueryable<T> query, bool? isDeleted)
        {
            query = ((IQueryable<IDeletableEntity>)query).Where<IDeletableEntity>(q => q.isDeleted == isDeleted).Cast<T>();
        }
    }
}
