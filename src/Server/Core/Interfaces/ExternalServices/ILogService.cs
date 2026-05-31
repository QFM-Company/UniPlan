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
        Task Log(string message , ExternalServicesEnums.LogType type);
        Task Log(Exception ex);

    }
}
