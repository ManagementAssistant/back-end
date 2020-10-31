
using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Core.Base.Model
{
    public abstract class EntityViewModel<T> : ViewModel where T : IEntity 
    {
        public EntityViewModel()
        {

        }

        public T Entity { get; set; }
    }
}
