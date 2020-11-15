using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _repositoryCompany;
        //private readonly ICompanyRepository _repositoryCompany;
        public CompanyService(/*ICompanyRepository repositoryCompany*/IRepository<Company> repositoryCompany)
        {
            _repositoryCompany = repositoryCompany;
            //_repositoryCompany = repositoryCompany;
        }
        public ApiResponse<IQueryable<Company>> GetCompanies()
        {
            ApiResponse<IQueryable<Company>> response = new ApiResponse<IQueryable<Company>>();
            response.Data = _repositoryCompany.ForJoin();
            response.isSuccess = true;

            return response;
        }
    }
}
