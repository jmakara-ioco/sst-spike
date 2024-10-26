using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Components
{
    public enum ConfigType
    {
        Alignment,
        HeaderSize,
        ChangeTextType,
        Bold,
        Underline,
        Italic,
        Indent,
        Clause,
        Signature,
        List,
        UserField,
        AutoNumber,
        RestartNumbering,
        Hyperlink
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AllowedConfigAttribute : Attribute
    {
        public AllowedConfigAttribute(ConfigType allowedType) : 
            this(allowedType, 0,0)
        {

        }

        public AllowedConfigAttribute(ConfigType allowedType, int minValue, int maxValue)
        {
            AllowedType = allowedType;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public ConfigType AllowedType { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
