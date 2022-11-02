using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
public class TeamMapper
{
    public static Team ToObject(DataRow row)
    {
        Team team = new Team();
        team.Id = Convert.ToString(row, "id");
        team.Name = Convert.ToString(row, "name");
        team.Logo = Convert.ToString(row, "logo");
        return team;

    }

    public static List<Team> ToList(DataTable table)
    {
        List<Team> list = new List<Team>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(ToObject(row));
        }
        return list;
    }
}
