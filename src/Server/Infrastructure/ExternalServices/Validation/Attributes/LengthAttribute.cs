namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public class LengthAttribute : ValidationAttribute
    {
        public int MaxLength { get; set; }

        public int MinLength { get; set; }

        public LengthAttribute(string errorMeesage, int maxLength, int minLength) : base(errorMeesage)
        {
            MaxLength = maxLength;
            MinLength = minLength;
        }

        public override bool Check(object? obj) 
        {
            if (obj == null)
                return false;

            string value = (string)obj;
            return value.Length >= MinLength && value.Length <= MaxLength;
        }
    }

}
