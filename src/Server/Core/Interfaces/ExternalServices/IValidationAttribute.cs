namespace Core.Interfaces.ExternalServices
{
    public interface IValidationAttribute
    {
        string ErrorMeesage { get; set; }

        bool Check(object? obj);
    }
}
