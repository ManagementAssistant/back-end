using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;

namespace BHA.ManagementAssistant.Nutritious.Model.Entity
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
