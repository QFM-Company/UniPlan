using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core.Interfaces.ExternalServices
{
    public interface ILog
    {
        void Log(string message , ExternalServicesEnums.LogType type);
        void Log(Exception ex);

    }
}
