using System.Numerics;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public class RangeAttribute<T> : ValidationAttribute where T : INumber<T>
    {
        public T MaxNumber { get; set; }

        public T MinNumber { get; set; }

        public RangeAttribute(string errorMeesage, T maxNumber, T minNumber) : base(errorMeesage)
        {
            MaxNumber = maxNumber;
            MinNumber = minNumber;
        }

        public override bool Check(object? obj)
        {
            if (obj == null)
                return false;

            T value = (T)obj;
            return value >= MinNumber && value <= MaxNumber;
        }
    }
}
