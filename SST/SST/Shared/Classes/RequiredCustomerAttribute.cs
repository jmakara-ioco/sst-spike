using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SST.Shared
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class RequiredCustomerAttribute : ValidationAttribute
    {
        //public const string DefaultErrorMessage = "The {0} field is required";

        public RequiredCustomerAttribute() : base() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type tp = validationContext.ObjectInstance.GetType();
            /*CustomerID*/
            var custProp = tp.GetProperty("CustomerID");
            bool hasCustomer = false;
            if (custProp != null)
            {
                Guid? custID = (Guid?)custProp.GetValue(validationContext.ObjectInstance);
                if ((custID != null) && (((Guid)custID) != Guid.Empty))
                    hasCustomer = true;
            }
            else
                return new ValidationResult("CustomerID not found on class");
            /*StoreCustomer*/
            var storeProp = tp.GetProperty("StoreCustomer");
            if (storeProp != null)
            {
                StoreCustomer cust = (StoreCustomer)storeProp.GetValue(validationContext.ObjectInstance);
                if (!string.IsNullOrEmpty(cust.Email))
                    hasCustomer = true;
            }
            else
                return new ValidationResult("StoreCustomer not found on class");
            if (hasCustomer)
                return ValidationResult.Success;
            return new ValidationResult("This field is required.", new string[] { "CustomerID" });
        }
    }
}
