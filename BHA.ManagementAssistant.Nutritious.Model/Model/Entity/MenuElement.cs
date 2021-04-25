using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Enums;
using System.Collections.Generic;

namespace BHA.ManagementAssistant.Nutritious.Model.Model.Entity
{
    public class MenuElement : IEntity
    {
        public int ID { get; set; }
        public int? MenuElementID { get; set; }
        public MenuType MenuTypeEnum { get; set; }
        public MenuElementType MenuElementTypeEnum { get; set; }

        public MenuElement OwnerMenuElement { get; set; }
        public ICollection<MenuElement> TenantMenuElement { get; set; }
    }
}
