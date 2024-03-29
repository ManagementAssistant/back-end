﻿using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using System.Collections.Generic;

namespace BHA.ManagementAssistant.Nutritious.Model.Entity
{
    public class User : IEntity, IOrganizationBasedEntity, IHierarchyBasedEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int OrganizationID { get; set; }
        public int HierarchyTypeEnum { get; set; }
        public Organization Organization { get; set; }

        public ICollection<Company> Company { get; set; }
        public ICollection<UserMenuTypeRelation> UserMenuTypeRelation { get; set; }
    }
}
