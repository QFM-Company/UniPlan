namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMeesage { get; set; }

        protected ValidationAttribute(string errorMeesage)
        {
            ErrorMeesage = errorMeesage;
        }

        public abstract bool Check(object? obj);
    }
}
