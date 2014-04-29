using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldNamwahSystem.Func
{
    class ServerHelper
    {
        public static ADODB.Connection ConnectMySQL()
        {
            return ServerHelper.ConnectMySQL("OldNamwahSystem");
        }

        public static ADODB.Connection ConnectMySQL(string DBName)
        {
            String StrConnect;
            ADODB.Connection Cnn = new ADODB.Connection();

            // MySQL ODBC 5.2 Unitcode Driver
            /* StrConnect = "Driver={MySQL ODBC 5.2 Unicode Driver};Server=NWERP;" & _
            "Port=3306;Option=4;Database=cheermain;Uid=kenneth;Pwd=kenneth"
            */

            // MySQL ODBC 5.1 Driver
            StrConnect = string.Format("Driver={0};Server=NWERP;Port=3306;Option=4;Database={1};Uid=kenneth;Pwd=kenneth", "MySQL ODBC 5.1 Driver", DBName);

            /*
            StrConnect = "Driver={MySQL ODBC 5.1 Driver};Server=NWERP;" +
                "Port=3306;Option=4;Database=OldNamwahSystem;Uid=kenneth;Pwd=kenneth";
*/

            Cnn.ConnectionString = StrConnect;
            Cnn.Open();
            return Cnn;
        }

        public static ADODB.Connection ConnectExchange(string Path)
        {
            ADODB.Connection Cnn = new ADODB.Connection();
            Cnn.Provider = "msdaipp.dso";
            Cnn.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
            Cnn.Open(Path, "Namwah", "ParaW0rld", -1);
            return Cnn;
        }

        public static string UserName = "";



    }
}
