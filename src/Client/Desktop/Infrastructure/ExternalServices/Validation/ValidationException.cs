namespace Infrastructure.ExternalServices.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMeesage) : base(errorMeesage)
        {
        }
    }
}
