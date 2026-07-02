using Core.Enums;

namespace Core.Interfaces.ExternalServices
{
    public interface ILogService
    {
        Task LogAsync(string message, ExternalServicesEnums.LogType type);
        Task LogAsync(Exception ex);

    }
}
