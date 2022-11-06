using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
public class SessionsMapper
{
    public static Sessions ToObject(DataRow row)
    {
        
        Sessions sessions = new(Convert.ToInt(row, "id"), Convert.ToDateTime(row, "dateTimeLogin"), Convert.ToTimeSpan(row, "timeLoggedIn"), Convert.ToInt(row, "idAgent"), Convert.ToString(row, "agentName"), Convert.ToInt(row, "idStation"), Convert.ToInt(row, "idCurrentCall"), Convert.ToString(row, "phoneNumber"), Convert.ToDateTime(row, "dateTimeAnswered"), Convert.ToTimeSpan(row, "timeIncall"));

        return sessions;

    }

    public static List<Sessions> ToList(DataTable table)
    {
        List<Sessions> list = new List<Sessions>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(ToObject(row));
        }
        return list;
    }
}


