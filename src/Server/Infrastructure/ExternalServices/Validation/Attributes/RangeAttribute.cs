using Core.Interfaces.ExternalServices;
using System.Numerics;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    internal class RangeAttribute<T> : Attribute, IValidationAttribute where T : INumber<T>
    {
        public string ErrorMeesage { get; set; }

        public T MaxNumber { get; set; }

        public T MinNumber { get; set; }

        public RangeAttribute(string errorMeesage, T maxNumber, T minNumber)
        {
            ErrorMeesage = errorMeesage;
            MaxNumber = maxNumber;
            MinNumber = minNumber;
        }

        public bool Check(object? obj) 
        {
            if (obj == null)
                return false;

            T value = (T)obj;
            return value >= MinNumber && value <= MaxNumber;
        }
    }
}
