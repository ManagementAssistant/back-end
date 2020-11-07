using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHA.ManagementAssistant.Nutritious.Core.Base.Entity
{
    public interface IPersonalityEntity : IEntity
    {
        int CreatedByUserID { get; set; }
        int? UpdatedByUserID { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
