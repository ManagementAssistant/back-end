using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHA.ManagementAssistant.Nutritious.Core.Base.Entity
{
    public interface IDeletableEntity : IEntity
    {
        int? DeletedByUserID { get; set; }
        DateTime? DeletedDate { get; set; }
        bool isDeleted { get; set; }
    }
}
