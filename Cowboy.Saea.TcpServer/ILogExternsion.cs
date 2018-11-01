using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    public static class ILogExternsion
    {
        public static void ErrorFormat(this ILogger logger,string msg,object o )
        {
            logger.Error( String.Format(msg, o));
        }
        public static void DebugFormat(this ILogger logger, string msg, object o)
        {
            logger.Debug(String.Format(msg, o));
        }
        public static void WarnFormat(this ILogger logger, string msg, object o)
        {
            logger.Warn(String.Format(msg, o));
        }
        public static void InfoFormat(this ILogger logger, string msg, object o)
        {
            logger.Info(String.Format(msg, o));
        }

    }
}
