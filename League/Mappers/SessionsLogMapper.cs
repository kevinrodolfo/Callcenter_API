using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
public class SessionsLogMapper
{
    public static SessionsLog ToObject(DataRow row)
    {
        SessionsLog sessionslog = new(Convert.ToInt(row, "id"), Convert.ToInt(row, "idSession"), Convert.ToDateTime(row, "dateTimeStart"), Convert.ToDateTime(row, "dateTimeEnd"), Convert.ToTimeSpan(row, "timeElapsed"), Convert.ToInt(row, "idStatus"), Convert.ToString(row, "statusDescription"));

        return sessionslog;

    }

    public static List<SessionsLog> ToList(DataTable table)
    {
        List<SessionsLog> list = new List<SessionsLog>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(ToObject(row));
        }
        return list;
    }
}


