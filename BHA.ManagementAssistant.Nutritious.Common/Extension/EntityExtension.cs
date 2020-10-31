using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Extension
{
    public static class EntityExtension
    {

        //private static ConcurrentDictionary<string, PropertyInfo> _entityPropertyCache = new ConcurrentDictionary<string, PropertyInfo>();

        //private static PropertyInfo GetPropertyInfo(Type entityType, string propertyName)
        //{
        //    string key = $"{entityType.FullName}.{propertyName}";
        //    if (_entityPropertyCache.ContainsKey(key))
        //    {

        //    }
        //}

        public static T SetPropertyValue<T>(this T Entity, string key, object value)
        {
            if (Entity.GetType().GetProperty(key) != null)
                Entity.GetType().GetProperty(key).SetValue(Entity, null);

            return Entity;
        }
    }
}
