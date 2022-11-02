using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
public class Team
{
    #region sql statements
    private static string select = "select id, name, logo from teams";
    #endregion
    #region attributes
    private string _id;
    private string _name;
    private string _logo;
    #endregion

    #region properties
    public string Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string Logo { get => Config.Configuration.Root + Config.Configuration.Files.Logos + _logo; set => _logo = value; }
    #endregion

    #region constructors
    public Team()
    {
        _id = "";
        _name = "";
        _logo = "";
    }

    public Team(string id, string name, string logo)
    {
        _id = id;
        _name = name;
        _logo = logo;
    }
    #endregion

    #region instance methods

    public static List<Team> GetAll()
    {
        SqlCommand command = new SqlCommand(select + " order by name");
        return TeamMapper.ToList(SqlServerConnection.ExecuteQuery(command));   
    }

    #endregion

    #region class methods

    #endregion
}

