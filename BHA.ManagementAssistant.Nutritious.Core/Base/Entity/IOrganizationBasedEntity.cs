namespace BHA.ManagementAssistant.Nutritious.Core.Base.Entity
{
    public interface IOrganizationBasedEntity : IEntity
    {
        int OrganizationID { get; set; }
    }
}
