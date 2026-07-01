using Core.Interfaces.ExternalServices;
using Infrastructure.ExternalServices.Validation.Enums;
using System.Reflection;

namespace Infrastructure.ExternalServices.Validation.Attributes
{


    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CompareAttribute : Attribute
    {
        public string OtherPropertyName { get; set; }
        public ComparisonType Comparison { get; set; }
        public string ErrorMeesage { get; set; }


        public CompareAttribute(string otherPropertyName, ComparisonType comparison, string errorMeesage)
        {
            OtherPropertyName = otherPropertyName;
            Comparison = comparison;
            ErrorMeesage = errorMeesage;
        }


        public bool Check(object? obj, object? otherValue)
        {
            if (obj == null || otherValue == null) return false;

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
    }
}