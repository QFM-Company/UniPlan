namespace Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMeesage) : base(errorMeesage)
        {
        }
    }
}
