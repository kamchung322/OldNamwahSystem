using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldNamwahSystem.Func
{
    public class ExchangeHelper
    {
        public static bool GetBoolField(ADODB.Field field)
        {
            if (field.Value == null)
                return false;
            else
                return bool.Parse(field.Value.ToString());

        }

        public static string GetStringField(ADODB.Field field)
        {
            if (field.Value == null)
                return "";
            else
                return field.Value.ToString().Trim();

        }

        public static int GetIntField(ADODB.Field field)
        {
            if (field.Value == null)
                return 0;
            else if (field.Value.ToString().Trim() == "")
                return 0;
            else
                return int.Parse(field.Value.ToString());

        }

        public static double GetDoubleField(ADODB.Field field)
        {
            if (field.Value == null)
                return 0;
            else if (field.Value.ToString().Trim() == "")
                return 0;
            else
                return double.Parse(field.Value.ToString());

        }

        public static float GetFloatField(ADODB.Field field)
        {
            if (field.Value == null)
                return 0;
            else if (field.Value.ToString().Trim() == "")
                return 0;
            else
                return float.Parse(field.Value.ToString());

        }

        public static DateTime GetDateTimeField(ADODB.Field field)
        {
            if (field.Value == null)
                return DateTime.MinValue;
            else if (field.Value.ToString().Trim() == "")
                return DateTime.MinValue;
            else
                return DateTime.Parse(field.Value.ToString());

        }

        //public static string 

    }
}
