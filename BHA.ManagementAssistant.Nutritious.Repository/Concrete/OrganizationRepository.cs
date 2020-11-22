using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using Microsoft.AspNetCore.Http;
using System;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Concrete
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private Organization _organization;
        private IQueryable<Organization> _queryOrganization;
        private IServiceProvider _serviceProvider;
        private IHttpContextAccessor _httpContextAccessor;

        public OrganizationRepository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            this._serviceProvider = serviceProvider;
            this._httpContextAccessor = httpContextAccessor;
        }

        private IQueryable<Organization> queryOrganization
        {
            get
            {
                _queryOrganization = _serviceProvider.GetService<IOrganizationRepository>()

                return _queryOrganization;
            }
        }

        private Organization organization
        {
            get
            {
                if (_organization == null)
                {
                    int currentOrganizationID = _httpContextAccessor.GetCurrentOrganizationID();
                    _organization = _repositoryOrganization.GetByID(currentOrganizationID);

                    if (_organization == null)
                    {
                        throw new Exception("organization.id.invalid");
                    }
                }

                return _organization;
            }
        }

        public Organization GetCurrentOrganization()
        {
            return organization;
        }

        public int GetCurrentOrganizationID()
        {
            return organization.ID;
        }

    }
}
