using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using VezaVI.Light.Shared;

namespace VezaVI.Light.ServerExtensions
{
    public static class QueryableExtensions 
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string orderByMember, string direction)
        {
            var queryElementTypeParam = Expression.Parameter(typeof(T));
            var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);
            var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

            var orderBy = Expression.Call(
                typeof(Queryable),
                direction == "ASC" ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(T), memberAccess.Type },
                query.Expression,
                Expression.Quote(keySelector));
            return query.Provider.CreateQuery<T>(orderBy);
        }

        private static MemberExpression GetProperty(Type rootType, ParameterExpression parameter, string fieldName)
        {
            string[] fieldNames = fieldName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (fieldNames.Length == 0)
                throw new Exception($"Property for field name '{fieldName}' not found.");
            if (fieldNames.Length == 1)
            {
                return Expression.Property(parameter, fieldNames[0]);
            }
            else
            {
                MemberExpression memberExpression = Expression.Property(parameter, fieldNames[0]);
                Type lastType = rootType;
                for (int i = 1; i < fieldNames.Length; i++)
                {
                    memberExpression = Expression.Property(memberExpression, fieldNames[i]);
                }
                return memberExpression;
            }
        }

        public static IQueryable<T> FilteredData<T>(this IQueryable<T> query, IList<VezaVIGridFilter> filters) where T : class, IVezaVIRecordBase
        {
            if (filters.Count > 0)
            {
                Expression body = Expression.Constant(true);
                ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                var uniqueFields = filters.GroupBy(x => x.Field).Select(g => g.First().Field).ToList();
                foreach (var field in uniqueFields)
                {
                    Expression orbody = Expression.Constant(false);
                    foreach (var filter in filters.Where(x => x.Field == field))
                    {
                        var property = GetProperty(typeof(T), parameter, filter.Field);
                        if (property.Type == typeof(bool))
                        {
                            bool value = Convert.ToBoolean(filter.Value.ToString());
                            var constant = Expression.Constant(value);

                            var expression = (filter.Equals) ? Expression.Equal(property, constant) : Expression.NotEqual(property, constant);
                            orbody = Expression.OrElse(orbody, expression);
                        }
                        else if (property.Type == typeof(int))
                        {
                            int value = Convert.ToInt32(filter.Value.ToString());
                            var constant = Expression.Constant(value);

                            var expression = (filter.Equals) ? Expression.Equal(property, constant) : Expression.NotEqual(property, constant);
                            orbody = Expression.OrElse(orbody, expression);
                        }
                        else if (property.Type == typeof(Guid))
                        {
                            Guid value = new Guid(filter.Value.ToString());
                            var constant = Expression.Constant(value);

                            var expression = (filter.Equals) ? Expression.Equal(property, constant) : Expression.NotEqual(property, constant);
                            orbody = Expression.OrElse(orbody, expression);
                        }
                        else if (property.Type.IsEnum)
                        {
                            int value = Convert.ToInt32(filter.Value.ToString());
                            var enumValue = Enum.ToObject(property.Type, value);
                            var constant = Expression.Constant(enumValue);
                            var expression = (filter.Equals) ? Expression.Equal(property, constant) : Expression.NotEqual(property, constant);
                            orbody = Expression.OrElse(orbody, expression);
                        }
                        else
                        {
                            var constant = (filter.Value == null) ? Expression.Constant(null) : Expression.Constant(filter.Value.ToString());

                            MethodInfo toStringMethod = typeof(object).GetMethod("ToString", Type.EmptyTypes);
                            MethodCallExpression innerExpression = Expression.Call(property, toStringMethod);

                            var expression = (filter.Equals) ? Expression.Equal(innerExpression, constant) : Expression.NotEqual(innerExpression, constant);
                            orbody = Expression.OrElse(orbody, expression);
                        }
                    }
                    body = Expression.AndAlso(body, orbody);
                }
                var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
                return query.Where(lambda);
            }
            else
                return query;
        }

        public static IQueryable<T> SearchedData<T>(this IQueryable<T> query, string searchText) where T : class, IVezaVIRecordBase
        {
            /*SOME LIGHT READING :P*/
            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower();
                var stringProperties = typeof(T).GetProperties().Where(prop => prop.PropertyType == typeof(string));
                if (stringProperties.Count() > 0)
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
                    MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string)/*, typeof(StringComparison)*/ });
                    MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                    List<MemberExpression> propertyExpressionList = new List<MemberExpression>();
                    Expression body = Expression.Constant(false);
                    foreach (var stringProperty in stringProperties)
                    {
                        if (stringProperty.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute>() == null)
                        {
                            MemberExpression propertyExpression0 = Expression.Property(parameter, stringProperty.Name);//property = x.Name for x.Name.Contains(a)                        
                            propertyExpressionList.Add(propertyExpression0);
                        }
                    }
                    foreach (var propertyExpression in propertyExpressionList)
                    {
                        MethodCallExpression innerExpression = Expression.Call(propertyExpression, toLowerMethod);
                        innerExpression = Expression.Call(innerExpression, containsMethod, Expression.Constant(searchText)/*, Expression.Constant(StringComparison.InvariantCultureIgnoreCase)*/);//call a method[Contains] on instance[Name] that takes constant argument[keyword] ===> Name.Contains(keyword)
                        body = Expression.OrElse(body, innerExpression);//Put Or between 'false' and Name.Contains(keyword) ==> Name.Contains(keyword) || false
                    }
                    Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(body, new[] { parameter });
                    query = query.Where(lambda);
                }
            }
            return query;
        }



        /**/
    }
}
