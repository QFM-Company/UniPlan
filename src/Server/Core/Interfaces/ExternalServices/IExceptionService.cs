
namespace Core.Interfaces.ExternalServices
{
    public interface IExceptionService
    {
        string GetExceptionMessage(Exception ex);
    }
}
