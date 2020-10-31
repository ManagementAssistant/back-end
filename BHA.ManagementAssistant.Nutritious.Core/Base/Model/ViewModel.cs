using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Core.Base.Model
{
    public abstract class ViewModel : IModel
    {
        public ViewModel()
        {

        }

        public int ID { get; set; }
    }
}
