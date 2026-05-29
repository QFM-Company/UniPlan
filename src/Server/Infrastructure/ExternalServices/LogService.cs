using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.ExternalServices;
using Core.Enums;
using System.Runtime.InteropServices.Marshalling;


namespace Infrastructure.ExternalServices
{
    public class LogService : ILog
    {
        public void Log(string message, ExternalServicesEnums.LogType logType)
        { 
            //some code
        }


        public void Log(Exception exception)
        {
            //some code
        }

    }
}
