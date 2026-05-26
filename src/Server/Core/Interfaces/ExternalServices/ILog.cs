using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.ExternalServices
{
    internal interface ILog
    {

        enum LogType
        {
            Info,
            Warning,
            Error
        }

        void Log(string message , LogType type);
        void Log(Exception ex);

    }
}
