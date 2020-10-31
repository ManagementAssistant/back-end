using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Core.Base.Model
{
    public abstract class FilterModel : IModel
    {
        public FilterModel()
        {

        }

        public int? ID { get; set; }
    }
}
