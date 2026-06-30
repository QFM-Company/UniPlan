using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    internal class LengthAttribute : Attribute, IValidationAttribute
    {
        public string ErrorMeesage { get; set; }

        public int MaxLength { get; set; }

        public int MinLength { get; set; }

        public LengthAttribute(string errorMeesage, int maxLength, int minLength)
        {
            ErrorMeesage = errorMeesage;
            MaxLength = maxLength;
            MinLength = minLength;
        }

        public bool Check(object? obj)
        {
            if (obj == null)
                return false;

            string value = (string)obj;
            return value.Length >= MinLength && value.Length <= MaxLength;
        }
    }

}
