using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Service.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repositoryCompany;
        public CompanyService(ICompanyRepository repositoryCompany)
        {
            _repositoryCompany = repositoryCompany;
        }
        public ApiResponse<IQueryable<Company>> GetCompanies()
        {
            ApiResponse<IQueryable<Company>> response = new ApiResponse<IQueryable<Company>>();
            response.Data = _repositoryCompany.GetAll();
            response.isSuccess = true;

            return response;
        }
    }
}
