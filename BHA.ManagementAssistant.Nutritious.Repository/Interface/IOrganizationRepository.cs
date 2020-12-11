using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.Repository.Interface
{
    public interface IOrganizationRepository
    {
        int GetCurrentOrganizationID();
        Organization GetCurrentOrganization();
    }
}
