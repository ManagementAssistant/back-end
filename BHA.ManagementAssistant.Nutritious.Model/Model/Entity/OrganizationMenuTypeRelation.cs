using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Model.Model.Entity
{
    public class OrganizationMenuTypeRelation : IEntity
    {
        public int ID { get; set; }
        public int OrganizationID { get; set; }
        public MenuType MenuTypeEnum { get; set; }

        public Organization Organization { get; set; }
    }
}