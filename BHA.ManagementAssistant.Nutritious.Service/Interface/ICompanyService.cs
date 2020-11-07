using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Service.Interface
{
    public interface ICompanyService
    {
        ApiResponse<IQueryable<Company>> GetCompanies();
    }
}
