using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dm.Common
{
    //Used for errorlog data into log file
    public static class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void ErrorLog(string message)
        {
            log.Error(message);
        }
      
    }
}
