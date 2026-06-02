using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core.Interfaces.ExternalServices
{
    public interface ILogService
    {
        Task LogAsync(string message , ExternalServicesEnums.LogType type);
        Task LogAsync(Exception ex);

    }
}
