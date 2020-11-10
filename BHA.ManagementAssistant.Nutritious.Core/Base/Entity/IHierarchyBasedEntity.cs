namespace BHA.ManagementAssistant.Nutritious.Core.Base.Entity
{
    public interface IHierarchyBasedEntity : IEntity
    {
        int HierarchyTypeEnum { get; set; }
    }
}
