using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VezaVI.Light.Shared
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class RequiredGuidAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field is required";
        public RequiredGuidAttribute() : base(DefaultErrorMessage) { }

        public RequiredGuidAttribute(string msg) : base(msg) { }

        public override bool IsValid(object value)
        {
            if ((value == null) || (value.ToString() == string.Empty))
                return false;
            try
            {
                Guid guid = new Guid(value.ToString());
                if (guid == Guid.Empty)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
