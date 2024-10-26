using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light
{
    public static class DbSetExtension
    {
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, params T[] records)
        where T : VezaVIGuidRecordBase
        {
            foreach (var data in records)
            {
                var exists = dbSet.AsNoTracking().Any(x => x.ID == data.ID);
                if (exists)
                {
                    dbSet.Update(data);
                    continue;
                }
                dbSet.Add(data);
            }
        }

        /*public static void AddOrUpdate<T>(this DbSet<T> dbSet, Expression<Func<T, object>> key, params T[] entities) where T : class
        {
            var context = dbSet.GetContext();
            var ids = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name);
            var t = typeof(T);
            foreach (T entity in entities)
            {
                var keyObject = key.Compile()(entity);
                PropertyInfo[] keyFields = keyObject.GetType().GetProperties().Select(p => t.GetProperty(p.Name)).ToArray();
                if (keyFields == null)
                {
                    throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
                }
                var keyVals = keyFields.Select(p => p.GetValue(entity));
                var nonTrackedEntities = dbSet.AsNoTracking().ToList();
                int i = 0;
                foreach (var keyVal in keyVals)
                {
                    nonTrackedEntities = nonTrackedEntities.Where(p => p.GetType().GetProperty(keyFields[i].Name).GetValue(p).Equals(keyVal)).ToList();
                    i++;
                }
                if (nonTrackedEntities.Any())
                {
                    var dbVal = nonTrackedEntities.FirstOrDefault();
                    var keyAttrs =
                        entity.GetType().GetProperties().Where(p => ids.Contains(p.Name)).ToList();
                    if (keyAttrs.Any())
                    {
                        foreach (var keyAttr in keyAttrs)
                        {
                            keyAttr.SetValue(entity,
                                dbVal.GetType()
                                    .GetProperties()
                                    .FirstOrDefault(p => p.Name == keyAttr.Name)
                                    .GetValue(dbVal));
                        }
                        context.Entry(dbVal).CurrentValues.SetValues(entity);
                        context.Entry(dbVal).State = EntityState.Modified;
                        return;
                    }
                }
                dbSet.Add(entity);
            }
        }*/
    }

    public static class HackyDbSetGetContextTrick
    {
        public static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
            where TEntity : class
        {
            return (DbContext)dbSet
                .GetType().GetTypeInfo()
                .GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
        }
    }
}
