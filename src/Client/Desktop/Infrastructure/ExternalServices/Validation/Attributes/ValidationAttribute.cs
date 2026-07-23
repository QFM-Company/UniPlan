namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        protected ValidationAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool Check(object? obj);
    }
}
