using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using System;

namespace BHA.ManagementAssistant.Nutritious.Model.Model.Entity
{
    public class Company : IDeletableEntity, IPersonalityEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CreatedByUserID { get; set; }
        public int? UpdatedByUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeletedByUserID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool isDeleted { get; set; }

        public User User { get; set; }
    }
}
