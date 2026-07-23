namespace Core.Interfaces.ExternalServices
{
    public interface IValidationService
    {
        void Validate<T>(T dto) where T : class;
    }
}
