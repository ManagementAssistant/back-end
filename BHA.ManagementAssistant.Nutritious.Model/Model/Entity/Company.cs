using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DateTime? DeleteDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
