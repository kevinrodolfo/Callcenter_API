using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
public class WeekMapper
    {
    public static Week ToObject(DataRow row)
    {
        Week week = new (Convert.ToInt(row, "id"), Convert.ToDateTime(row, "date"), Convert.ToInt(row, "status"));
        
        return week;

    }

    public static List<Week> ToList(DataTable table)
    {
        List<Week> list = new List<Week>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(ToObject(row));
        }
        return list;
    }
}

