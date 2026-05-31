using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices
{
    public class LogService : ILogService
    {
        // Used to stop multiple requests from writing to the file at the exact same time.
        private static readonly SemaphoreSlim _lock = new(1, 1);

        private readonly string _logsFolder;
        private readonly IExceptionService _exceptionService;

        public LogService(IExceptionService exceptionService)
        {
            _logsFolder = Path.Combine(AppContext.BaseDirectory, "Logs");
            _exceptionService = exceptionService;
        }

        public async Task Log(string message, ExternalServicesEnums.LogType logType)
        {
            // Because your interface is sync, we call the async method safely.
            await WriteLogAsync(message, logType);
        }

        public async Task Log(Exception exception)
        {
            if (exception == null) return;
            await Log(_exceptionService.GetExceptionMessage(exception), ExternalServicesEnums.LogType.Error);
        }

        private async Task WriteLogAsync(
            string message,
            ExternalServicesEnums.LogType logType)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            // Create file name like: server-2026-05-31.log
            var fileName = $"server-{DateTime.Now:yyyy-MM-dd}.log";

            var filePath = Path.Combine(_logsFolder, fileName);

            // Build one log entry.
            var logText = BuildLogText(message, logType);

            // Wait until no other request is writing.
            await _lock.WaitAsync();

            try
            {
                if(!Directory.Exists(_logsFolder))
                     Directory.CreateDirectory(_logsFolder);

                // Append the log to the file.
                // UTF8 is a safe standard encoding.
                await File.AppendAllTextAsync(filePath, logText, Encoding.UTF8);

                if(Directory.GetFiles(_logsFolder).Length > 40)
                {
                    // If there are more than 40 log files, delete the oldest one.
                    var oldestFile = Directory.GetFiles(_logsFolder)
                        .OrderBy(f => File.GetCreationTime(f))
                        .FirstOrDefault();
                    if (oldestFile != null)
                    {
                        File.Delete(oldestFile);
                    }
                }

            }
            finally
            {
                // Always release the lock, even if writing fails.
                _lock.Release();
            }
        }

        private static string BuildLogText(
            string message,
            ExternalServicesEnums.LogType logType)
        {
            var builder = new StringBuilder();

            builder.AppendLine("--------------------------------------------------");

            builder.AppendLine($"Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");

            // Info, Warning, Error.
            builder.AppendLine($"Level: {logType}");

            // The normal message.
            builder.AppendLine($"Message: {message}");

            builder.AppendLine();

            return builder.ToString();
        }
    }
}