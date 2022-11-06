using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
public class CallsMapper
{
    public static Calls ToObject(DataRow row)
    {
        Calls calls = new(Convert.ToInt(row, "callId"), Convert.ToString(row, "phoneNumber"), Convert.ToDateTime(row, "dateTimeReceived"), Convert.ToDateTime(row, "dateTimeAnswered"), Convert.ToDateTime(row, "dateTimeEnded"), Convert.ToTimeSpan(row, "timeInQueue"), Convert.ToTimeSpan(row, "timeInCall"), Convert.ToInt(row, "idStatus"), Convert.ToString(row, "callStatus"), Convert.ToInt(row, "idAgent"), Convert.ToString(row, "name"), Convert.ToInt(row, "idStation"));

        return calls;

    }

    public static List<Calls> ToList(DataTable table)
    {
        List<Calls> list = new List<Calls>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(ToObject(row));
        }
        return list;
    }
}


