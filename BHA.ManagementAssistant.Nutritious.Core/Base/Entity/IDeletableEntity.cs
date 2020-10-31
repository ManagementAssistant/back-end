using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Core.Base.Entity
{
    public interface IDeletableEntity : IEntity
    {
        int? DeletedByUserID { get; set; }
        DateTime? DeleteDate { get; set; }
        bool isDeleted { get; set; }
    }
}
