using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;

namespace BHA.ManagementAssistant.Nutritious.Repository.Interface
{
    public interface IOrganizationRepository
    {
        int GetCurrentOrganizationID();
        Organization GetCurrentOrganization();
    }
}
