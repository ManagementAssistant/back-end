﻿using BHA.ManagementAssistant.Nutritious.Common.Constant;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using System;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Base
{
    partial class MARepository<T>
    {
        private IQueryable<T> GetQuery(IQueryable<T> query, bool forJoin, bool isDeleted)
        {
            return CreateQuery(query, forJoin, isDeleted);
        }

        private IQueryable<T> CreateQuery(IQueryable<T> query, bool forJoin, bool isDeleted)
        {
            if (forJoin)
            {
                return CreateQueryForJoin(query, isDeleted);
            }

            return CreateQueryGetAll(query, isDeleted);
        }

        private IQueryable<T> CreateQueryGetAll(IQueryable<T> query, bool isDeleted)
        {
            return GetFilterForEntityType(query, isDeleted);
        }

        private IQueryable<T> CreateQueryForJoin(IQueryable<T> query, bool isDeleted)
        {
            ApplyDeletedFilters(ref query, isDeleted);

            return query;
        }

        private IQueryable<T> GetFilterForEntityType(IQueryable<T> query, bool isDeleted)
        {
            if (typeof(T).Is(EntityType.SpecificEntity))
            {
                return query.Where<T, ISpecificEntity>(q => q.ID == _repositoryOrganization.GetCurrentOrganizationID());
            }

            if (typeof(T).Is(EntityType.DeletableEntity))
            {
                ApplyDeletedFilters(ref query, isDeleted);
            }

            if (typeof(T).Is(EntityType.OrganizationBasedEntity))
            {
                ApplyOrganizationFilters(ref query);
            }

            if (typeof(T).Is(EntityType.CommonEntity) == false)
            {
                ApplyFilterForUser(query);
            }

            return query;
        }

        private void ApplyOrganizationFilters(ref IQueryable<T> query)
        {
            if (typeof(T).Is(EntityType.HierarchyBasedEntity))
            {
                if (_repositoryOrganization.GetCurrentOrganization().isHierarchical)
                {
                    ApplyFilterHierarchical(ref query);
                }
            }

            if (typeof(T).Is(EntityType.OrganizationBasedEntity))
            {
                ApplyOrganizationBasedEntity(ref query, _repositoryOrganization.GetCurrentOrganizationID());
            }
        }

        private void ApplyDeletedFilters(ref IQueryable<T> query, bool isDeleted)
        {
            if (typeof(T).Is(EntityType.DeletableEntity))
            {
                query = query.Where<T, IDeletableEntity>(q => q.isDeleted == isDeleted);
            }
        }

        private void ApplyFilterHierarchical(ref IQueryable<T> query)
        {
            query = query.Where<T, IHierarchyBasedEntity>(q => q.HierarchyTypeEnum <= _repositoryUser.GetCurrentUser().HierarchyTypeEnum);
        }

        private IQueryable<T> ApplyFilterForUser(IQueryable<T> query)
        {
            return query.Where<T, IPersonalityEntity>(q => q.CreatedByUserID == _repositoryUser.GetCurrentUserID());
        }

        private void ApplyOrganizationBasedEntity(ref IQueryable<T> query, int organizationID)
        {
            IQueryable<int> ownerUserIds = _repositoryUser.ForJoin().Where(q => q.OrganizationID == organizationID).Select(o => o.ID);

            query = query.Where<T, IPersonalityEntity>(q => ownerUserIds.Contains(q.CreatedByUserID));
        }

        private void BeforeCreateOperation(ref T entity)
        {
            if (entity is IDeletableEntity)
            {
                entity.SetCreateDeletableEntity();
            }

            if (entity is IPersonalityEntity)
            {
                entity.SetCreatePersonalityEntity(_repositoryUser.GetCurrentUserID());
            }
        }

        private void BeforeDeleteOperation(ref T entity)
        {
            if (entity is IDeletableEntity)
            {
                entity.SetDeleteDeletableEntity(_repositoryUser.GetCurrentUserID());
            }
        }

        private void BeforeUpdateOperation(ref T entity)
        {
            if (entity is IPersonalityEntity)
            {
                entity.SetUpdatePersonalityEntity(_repositoryUser.GetCurrentUserID());
            }
        }

    }
}
