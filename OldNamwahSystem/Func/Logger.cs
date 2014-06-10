using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace OldNamwahSystem.Func
{
    public class Logger
    {
        static Logger()
        {
            GlobalContext.Properties["appname"] = "OldNamwahSystem";
            string Log4NetPath = string.Format("{0}\\{1}", @"\\NWCITRIX\AppLogFiles", "Log4NetFromTom.Config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Log4NetPath));
        }

        public static ILog For(object LoggedObject)
        {
            if (LoggedObject != null)
                return For(LoggedObject.GetType());
            else
                return For(null);
        }

        public static ILog For(Type ObjectType)
        {
            if (ObjectType != null)
                return LogManager.GetLogger(ObjectType.Name);
            else
                return LogManager.GetLogger(string.Empty);
        }
    }
}
