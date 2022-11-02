using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
public class GameMapper
{
    public static Game ToObject(DataRow row)
    {
        Game game = new(Convert.ToInt(row, "id"), Convert.ToInt(row, "idWeek"), Convert.ToTimeSpan(row, "time"),Convert.ToString(row,"idField"), Convert.ToString(row, "idTeamVisitor"), Convert.ToInt(row, "scoreVisitor"), Convert.ToString(row, "idTeamHome"), Convert.ToInt(row, "scoreHome"), Convert.ToInt(row, "status"));

        return game;

    }

    public static List<Game> ToList(DataTable table)
    {
        List<Game> list = new List<Game>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(ToObject(row));
        }
        return list;
    }
}


