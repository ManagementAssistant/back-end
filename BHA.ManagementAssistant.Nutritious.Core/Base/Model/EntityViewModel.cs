
using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;

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
