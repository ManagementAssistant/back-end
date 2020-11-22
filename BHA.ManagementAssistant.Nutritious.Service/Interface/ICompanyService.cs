using BHA.ManagementAssistant.Nutritious.Core.BaseResponse;
using BHA.ManagementAssistant.Nutritious.Core.Service.Interface;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Service.Interface
{
    public interface ICompanyService: IEntityService<Company>
    {
        ApiResponse<IQueryable<Company>> GetCompanies();
    }
}
