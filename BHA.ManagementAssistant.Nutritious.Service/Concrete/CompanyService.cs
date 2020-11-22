using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Core.Service.Concrete;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class CompanyService : EntityService<Company>, ICompanyService
    {
        private readonly IRepository<Company> _repositoryCompany;

        public CompanyService(IRepository<Company> repositoryCompany): base(repositoryCompany)
        {
            _repositoryCompany = repositoryCompany;
        }
        public ApiResponse<IQueryable<Company>> GetCompanies()
        {
            ApiResponse<IQueryable<Company>> response = new ApiResponse<IQueryable<Company>>();
            response.Success();
            response.Data = _repositoryCompany.ForJoin();

            return response;
        }
    }
}
