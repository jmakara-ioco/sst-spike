using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{
    public static class IDragableElementExtensions
    {

        public static List<AllowedConfigAttribute> GetAttributes(this IDragableElement element)
        {
            return element.GetType().GetCustomAttributes<AllowedConfigAttribute>().ToList();
        }

        public static Dictionary<ConfigType, string> GetConfigs(this IDragableElement element)
        {
            Dictionary<ConfigType, string> valuePairs = new Dictionary<ConfigType, string>();
            if (element != null)
            {
                var attributes = element.GetType().GetCustomAttributes<AllowedConfigAttribute>();
                var values = element.GetConfigValues();
                foreach (var attribute in attributes)
                {
                    var value = values.ContainsKey(attribute.AllowedType) ? values[attribute.AllowedType] : "";
                    valuePairs.Add(attribute.AllowedType, value);
                }
            }
            return valuePairs;
        }

        public static Dictionary<ConfigType, string> GetConfigValues(this IDragableElement element)
        {
            Dictionary<ConfigType, string> valuePairs = new Dictionary<ConfigType, string>();
            if ((element != null) && (!string.IsNullOrEmpty(element.ConfigOptions)))
            {
                var options = JsonSerializer.Deserialize<IList<ConfigValue>>(element.ConfigOptions, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (options != null)
                    return options.ToDictionary(o => (ConfigType)o.Key, o => o.Value);
            }
            return valuePairs;
        }

        public static void SetConfigValue(this IDragableElement element, ConfigType type, string value)
        {
            var options = element.GetConfigValues().Select(x => new ConfigValue() { Key = (int)x.Key, Value = x.Value }).ToList();
            var option = options.FirstOrDefault(x => x.Key == (int)type);
            if (option != null)
            {
                option.Value = value;
            }
            else
            {
                options.Add(new ConfigValue() { Key = (int)type, Value = value });
            }
            element.ConfigOptions = JsonSerializer.Serialize(options);
        }

        public static int GetLevel(this IDragableElement element)
        {
            var indent = element.GetConfigValues().FirstOrDefault(x => x.Key == ConfigType.Indent);
            if (indent.Value != null)
            {
                return VezaVIUtils.CastToInt32(indent.Value.Replace($"{ConfigType.Indent.ToString().ToLower()}-", ""));
            }
            return 0;
        }

        public static bool AutoNumber(this IDragableElement element)
        {
            var autoNumber = element.GetConfigValues().FirstOrDefault(x => x.Key == ConfigType.AutoNumber);
            if (autoNumber.Value != null)
            {
                return (autoNumber.Value == "AutoNumber");
            }
            return false;
        }

        public static bool RestartNumbering(this IDragableElement element)
        {
            var resetNumber = element.GetConfigValues().FirstOrDefault(x => x.Key == ConfigType.RestartNumbering);
            if (resetNumber.Value != null)
            {
                return (resetNumber.Value == "RestartNumbering");
            }
            return false;
        }

    }
}
