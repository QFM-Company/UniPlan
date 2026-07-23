using System.Collections;
using System.Numerics;
using System.Linq;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public class RangeAttribute<T> : ValidationAttribute where T : INumber<T>
    {
        public T MaxNumber { get; set; }

        public T MinNumber { get; set; }

        public RangeAttribute(string errorMeesage, T minNumber, T maxNumber) : base(errorMeesage)
        {
            MaxNumber = maxNumber;
            MinNumber = minNumber;
        }

        public override bool Check(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is ICollection<T> col)
            {
                T? min = col.Min();
                T? max = col.Max();

                return ( min == null || max == null ) || ( min >= MinNumber && max <= MaxNumber );
            }

            T value = (T)obj;
            return value >= MinNumber && value <= MaxNumber;
        }
    }
}
