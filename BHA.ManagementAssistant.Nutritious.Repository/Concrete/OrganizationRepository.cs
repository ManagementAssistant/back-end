using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Concrete
{
    public class OrganizationRepository : IOrganizationRepository
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

        private Organization organization
        {
            get
            {
                if (_organization == null)
                {
                    IRepository<Organization> repositoryOrganization = _serviceProvider.GetService<IRepository<Organization>>();
                    _organization = repositoryOrganization.GetByID(this.GetCurrentOrganizationID());

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
            return _httpContextAccessor.GetCurrentOrganizationID();
        }
    }
}
