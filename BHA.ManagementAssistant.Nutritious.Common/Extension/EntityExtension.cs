using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class EntityExtension
    {

        private static ConcurrentDictionary<string, PropertyInfo> _entityPropertyCache = new ConcurrentDictionary<string, PropertyInfo>();

        private static PropertyInfo GetPropertyInfo(Type entityType, string propertyName)
        {
            string key = $"{entityType.FullName}.{propertyName}";
            if (_entityPropertyCache.ContainsKey(key))
            {
                return _entityPropertyCache.GetType().GetProperty(key);
            }

            return null;
        }

        public static T SetPropertyValue<T>(this T Entity, string key, object value)
        {
            //Bu yöntem entityler cachelenmediğinden dolayı zahmetli oluyor 
            //if (Entity.GetType().GetProperty(key) != null)
            //    Entity.GetType().GetProperty(key).SetValue(Entity, null);

            GetPropertyInfo(Entity.GetType(), key).SetValue(Entity, value);

            return Entity;
        }


    }
}
