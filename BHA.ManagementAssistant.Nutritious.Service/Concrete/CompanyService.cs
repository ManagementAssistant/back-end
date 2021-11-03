using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Core.Service.Concrete;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class CompanyService : EntityService<Company>, ICompanyService
    {
        public CompanyService(IRepository<Company> repositoryCompany) : base(repositoryCompany)
        {
        }
        public IQueryable<Company> GetCompanies()
        {
            return this.Repository.GetAll();
        }
    }
}
