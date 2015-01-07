using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace NamwahSystem.Model.Func
{
    public class ServerHelper
    {
        public static MySqlConnection ConnectToMySQL()
        {
            return ServerHelper.ConnectToMySQL(Glob.DefaultDatabase);
        }

        public static MySqlConnection ConnectToMySQL(string DBName)
        {
            string StrConn = string.Format("server=nwcitrix;uid=kenneth;pwd=kenneth;database={0}", DBName);
            MySqlConnection cnn = new MySqlConnection(StrConn);
            cnn.Open();
            return cnn;
        }

        public static ADODB.Connection ConnectExchange(string Path)
        {
            ADODB.Connection Cnn = new ADODB.Connection();
            Cnn.Provider = "msdaipp.dso";
            Cnn.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
            Cnn.Open(Path, "Namwah", "ParaW0rld", -1);
            return Cnn;
        }
    }
}
