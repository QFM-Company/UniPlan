using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowedValuesAttribute : Attribute, IValidationAttribute
    {
        public string ErrorMeesage { get; set; }
        public object[] AllowedValues { get; set; }

        public AllowedValuesAttribute(string errorMeesage, params object[] allowedValues)
        {
            ErrorMeesage = errorMeesage;
            AllowedValues = allowedValues;
        }

        public bool Check(object? obj)
        {
            if (obj == null)
                return false;

            return AllowedValues.Contains(obj);
        }
    }

}
