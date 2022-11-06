using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
public class SessionsLog
{

    #region sql statements
    private static string select = "select id, idSession, dateTimeStart, dateTimeEnd, timeElapsed, idStatus, statusDescription from viewSessionLog;";
    #endregion

    #region attributes
    private int _id;
    private int _idSession;
    private DateTime _dateTimeStart;
    private DateTime _dateTimeEnd;
    private TimeSpan _timeElapsed;
    private int _idStatus;
    private string _statusDescription;
    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public int IdSession { get => _idSession; set => _idSession = value; }
    public DateTime DateTimeStart { get => _dateTimeStart; set => _dateTimeStart = value; }
    public DateTime DateTimeEnd { get => _dateTimeEnd; set => _dateTimeEnd = value; }
    public TimeSpan TimeElapsed { get => _timeElapsed; set => _timeElapsed = value; }
    public int IdStatus { get => _idStatus; set => _idStatus = value; }
    public string StatusDescription { get => _statusDescription; set => _statusDescription = value; }
    
    
    



    #endregion

    #region constructors

    public SessionsLog()
    {
        _id = 0;
        _idSession = 0;
        _dateTimeStart = new DateTime();
        _dateTimeEnd = new DateTime();
        _timeElapsed = new TimeSpan();
        _idStatus = 0;
        _statusDescription = "";
    }


    

    public SessionsLog(int id, int idSession, DateTime dateTimeStart, DateTime dateTimeEnd, TimeSpan timeElapsed, int idStatus, string statusDescription)
    {
        _id = id;
        _idSession = idSession;
        _dateTimeStart = dateTimeStart;
        _dateTimeEnd = dateTimeEnd;
        _timeElapsed = timeElapsed;
        _idStatus = idStatus;
        _statusDescription = statusDescription;
    }

    #endregion

    #region instance methods

    public static List<SessionsLog> GetAll()
    {
        //List<Week> list = new List<Week>();
        //list.Add(new Week(1, new DateTime(2022 - 10 - 9), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 16), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 23), 0));
        //return list;

        SqlCommand command = new SqlCommand(select);
        return SessionsLogMapper.ToList(SqlServerConnection.ExecuteQuery(command));
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

