using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Components
{
    public static class TypeExtensions
    {

        public static PropertyInfo GetSmartProperty(this Type type, string propName)
        {
            if (propName == null)
                return null;
            if (propName.Contains("."))
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                if (type.GetProperty(temp[0]) == null)
                    return null;
                return type.GetProperty(temp[0]).PropertyType.GetSmartProperty(temp[1]);
            }
            else
            {
                if (type.GetProperty(propName) == null)
                    return null;
                return type.GetProperty(propName);
            }
        }

        public static object GetSmartPropertyValue(object src, string propName)
        {
            if (src == null) 
                throw new ArgumentException("Value cannot be null.", "src");
            if (propName == null) 
                throw new ArgumentException("Value cannot be null.", "propName");

            if (propName.Contains("."))
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetSmartPropertyValue(GetSmartPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop != null ? prop.GetValue(src, null) : null;
            }
        }

    }
}
