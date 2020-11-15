using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using System;
using System.Collections.Generic;

namespace BHA.ManagementAssistant.Nutritious.Model.Model.Entity
{
    public class Organization : IEntity, ISpecificEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isHierarchical { get; set; }

        public ICollection<User> User { get; set; }
    }
}
