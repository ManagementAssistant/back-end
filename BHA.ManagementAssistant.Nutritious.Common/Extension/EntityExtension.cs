using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

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
        //        return _entityPropertyCache.GetType().GetProperty(key);
        //    }

        //    return null;
        //}

        //public static T SetPropertyValue<T>(this T Entity, string key, object value)
        //{
        //    //Bu yöntem entityler cachelenmediğinden dolayı zahmetli oluyor 
        //    //if (Entity.GetType().GetProperty(key) != null)
        //    //    Entity.GetType().GetProperty(key).SetValue(Entity, null);

        //    GetPropertyInfo(Entity.GetType(), key).SetValue(Entity, value);

        //    return Entity;
        //}

        public static bool Is(this Type type, string entityType)
        {
            if (type.GetInterface(entityType) != null)
            {
                return true;
            }

            return false;
        }

        public static IQueryable<TEntity> Where<TEntity, T>(this IQueryable<TEntity> query, Expression<Func<T, bool>> expression)
        {
            return ((IQueryable<T>)query).Where<T>(expression).Cast<TEntity>();
        }

        public static void SetCreateDeletableEntity<T>(this T entity)
           where T : class, IEntity
        {
            if (entity is IDeletableEntity)
            {
                IDeletableEntity deletableEntity = entity as IDeletableEntity;
                deletableEntity.isDeleted = false;
            }
        }

        public static void SetCreatePersonalityEntity<T>(this T entity, int userID)
           where T : class, IEntity
        {
            if (entity is IPersonalityEntity)
            {
                IPersonalityEntity personalityEntity = entity as IPersonalityEntity;
                personalityEntity.CreateDate = DateTime.Now;
                personalityEntity.CreatedByUserID = userID;
            }
        }

        public static void SetUpdatePersonalityEntity<T>(this T entity, int userID)
           where T : class, IEntity
        {
            if (entity is IPersonalityEntity)
            {
                IPersonalityEntity personalityEntity = entity as IPersonalityEntity;
                personalityEntity.UpdateDate = DateTime.Now;
                personalityEntity.UpdatedByUserID = userID;
            }
        }

        public static void SetDeleteDeletableEntity<T>(this T entity, int userID)
           where T : class, IEntity
        {
            if (entity is IDeletableEntity)
            {
                IDeletableEntity deletableEntity = entity as IDeletableEntity;
                deletableEntity.isDeleted = true;
                deletableEntity.DeletedDate = DateTime.Now;
                deletableEntity.DeletedByUserID = userID;
            }
        }

    }
}
