using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
public class Game
    {
    
    #region sql statements
    private static string select = "select id, idWeek, time, idField, idTeamVisitor, scoreVisitor, idTeamHome, scoreHome, status from games";
    #endregion

    #region attributes
    private int _id;
    private int _weeks;
    private TimeSpan _time;
    private string _field;
    private string _visitor;
    private int _visitorScore;
    private string _home;
    private int _homeScore;
    private int _status;
    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public int Week { get => _weeks; set => _weeks = value; }
    public TimeSpan Time { get => _time; set => _time = value; }
    public string Field { get => _field; set => _field = value; }
    public string Visitor { get => _visitor; set => _visitor = value; }
    public int VisitorScore { get => _visitorScore; set => _visitorScore = value; }
    public string Home { get => _home; set => _home = value; }
    public int HomeScore { get => _homeScore; set => _homeScore = value; }
    public string Status { get => ((Status)_status).ToString(); set => ((Status)_status).ToString(); }



    #endregion

    #region constructors

    public Game()
    {
        _id = 0;
        _weeks = 0;
        _time = new TimeSpan();
        _field = "";
        _visitor = "";
        _visitorScore = 0;
        _home = "" ;
        _homeScore = 0;
        _status = 0;
    }

    public Game(int id, int weeks, TimeSpan time, string field, string visitor, int visitorScore, string home, int homeScore, int status)
    {
        _id = id;
        _weeks = weeks;
        _time = time;
        _field = field;
        _visitor = visitor;
        _visitorScore = visitorScore;
        _home = home;
        _homeScore = homeScore;
        _status = status;
    }

    #endregion

    #region instance methods

    public static List<Game> GetAll()
    {
        //List<Week> list = new List<Week>();
        //list.Add(new Week(1, new DateTime(2022 - 10 - 9), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 16), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 23), 0));
        //return list;

        SqlCommand command = new SqlCommand(select);
        return GameMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }

    #endregion 
    #region class methods
    public static int Finish (int id, int scoreVisitor, int scoreHome)
    {
        string statement = "spFinishGame";
        SqlCommand command = new SqlCommand(statement);
        command.Parameters.AddWithValue("@idGame", id);
        command.Parameters.AddWithValue("@scoreVisitor", scoreVisitor);
        command.Parameters.AddWithValue("@scoreHome", scoreHome);
        return SqlServerConnection.ExecuteProcedure(command);
    }
    #endregion
}

