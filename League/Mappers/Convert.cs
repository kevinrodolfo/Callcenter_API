using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
public class Convert
    {
        public static string ToString(DataRow row, string fieldName)
    {
        if (row[fieldName] != DBNull.Value) return (string)row[fieldName]; else return "";
    }
    public static int ToInt(DataRow row, string fieldName)
    {
        if (row[fieldName] != DBNull.Value) return (int)row[fieldName]; else return 0;
    }
    public static DateTime ToDateTime(DataRow row, string fieldName)
    {
        if (row[fieldName] != DBNull.Value) return (DateTime)row[fieldName]; else return new DateTime();
    }
    public static TimeSpan ToTimeSpan(DataRow row, string fieldName)
    {
        if (row[fieldName] != DBNull.Value) return (TimeSpan)row[fieldName]; else return new TimeSpan();
    }
}

