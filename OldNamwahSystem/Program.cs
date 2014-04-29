using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using log4net;

namespace OldNamwahSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            GlobalContext.Properties["appname"] = "OldNamwahSystem";
            string Log4NetPath = string.Format("{0}\\{1}", Application.StartupPath, "Log4NetFromTom.xml");
            //string Log4NetPath = string.Format("{0}\\{1}", Application.StartupPath, "Log4Net.Config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Log4NetPath));
            
            Application.Run(new frmMain());
        }
    }
}
