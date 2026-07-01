using Core.Interfaces.ExternalServices;
using Infrastructure.ExternalServices.Validation.Enums;
using System.Reflection;

namespace Infrastructure.ExternalServices.Validation.Attributes
{


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CompareAttribute : Attribute, IValidationAttribute
    {
        public string ErrorMeesage { get; set; }
        public string OtherPropertyName { get; set; }
        public ComparisonType Comparison { get; set; }

        public CompareAttribute(string otherPropertyName, ComparisonType comparison, string errorMeesage)
        {
            OtherPropertyName = otherPropertyName;
            Comparison = comparison;
            ErrorMeesage = errorMeesage;
        }

        public bool Check(object? obj,object parentObject, Type propertyes)
        {
            if (obj == null || propertyes == null || parentObject == null) return false;

            var otherProperty = propertyes.GetProperty(OtherPropertyName);
            if (otherProperty == null) return false;

            var otherValue = otherProperty.GetValue(parentObject);
            if (otherValue == null) return false;

            if (obj is IComparable comparableValue && otherValue is IComparable comparableOther)
            {
                int result = comparableValue.CompareTo(comparableOther);

                return Comparison switch
                {
                    ComparisonType.GreaterThan => result > 0,
                    ComparisonType.LessThan => result < 0,
                    ComparisonType.Equal => result == 0,
                    ComparisonType.NotEqual => result != 0,
                    _ => false
                };
            }

            return false;
        }

        public bool Check(object? obj) => throw new NotImplementedException("استخدم Overload التي تستقبل parentObject");
    }
}