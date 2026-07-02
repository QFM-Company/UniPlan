namespace Infrastructure.ExternalServices.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowedValuesAttribute : ValidationAttribute
    {
        public object[] AllowedValues { get; set; }

        public AllowedValuesAttribute(string errorMeesage, params object[] allowedValues) : base(errorMeesage)
        {
            AllowedValues = allowedValues;
        }

        public override bool Check(object? obj)
        {
            if (obj == null)
                return false;

            return AllowedValues.Contains(obj);
        }
    }

}
