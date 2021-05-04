using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Model.Model.Entity
{
    public class UserMenuTypeRelation : IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public MenuType MenuTypeEnum { get; set; }

        public User User { get; set; }
    }
}
