using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
public class Sessions
{

    #region sql statements
    private static string select = "select id, dateTimeLogin, timeLoggedIn, idAgent, agentName, idStation, idCurrentCall, phoneNumber, dateTimeAnswered, timeIncall from viewSessions";
    #endregion

    #region attributes
    private int _id;
    private DateTime _dateTimeLogin;
    private TimeSpan _timeLoggedIn;
    private int _idAgent;
    private string _agentName;
    private int _idStation;
    private int _idCurrentCall;
    private string _phoneNumber;
    private DateTime _dateTimeAnswered;
    private TimeSpan _timeIncall;
    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public DateTime DateTimeLogin { get => _dateTimeLogin; set => _dateTimeLogin = value; }
    public TimeSpan TimeLoggedIn { get => _timeLoggedIn; set => _timeLoggedIn = value; }
    public int IdAgent { get => _idAgent; set => _idAgent = value; }
    public string AgentName { get => _agentName; set => _agentName = value; }
    public int IdStation { get => _idStation; set => _idStation = value; }
    public int IdCurrentCall { get => _idCurrentCall; set => _idCurrentCall = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public DateTime DateTimeAnswered { get => _dateTimeAnswered; set => _dateTimeAnswered = value; }
    public TimeSpan TimeInCall { get => _timeIncall; set => _timeIncall = value; }
    
    



    #endregion

    #region constructors

    public Sessions()
    {
        _id = 0;
        _dateTimeLogin = new DateTime();
        _timeLoggedIn = new TimeSpan();
        _idAgent = 0;
        _agentName = "";
        _idStation = 0;
        _idCurrentCall = 0;
        _phoneNumber = "";
        _dateTimeAnswered = new DateTime();
        _timeIncall = new TimeSpan();
    }


    public Sessions(int id, DateTime dateTimeLogin, TimeSpan timeLoggedIn, int idAgent, string agentName, int idStation, int idCurrentCall, string phoneNumber, DateTime dateTimeAnswered, TimeSpan timeIncall)
    {
        _id = id;
        _dateTimeLogin = dateTimeLogin;
        _timeLoggedIn = timeLoggedIn;
        _idAgent = idAgent;
        _agentName = agentName;
        _idStation = idStation;
        _idCurrentCall = idCurrentCall;
        _phoneNumber = phoneNumber;
        _dateTimeAnswered = dateTimeAnswered;
        _timeIncall = timeIncall;
    }

    #endregion

    #region instance methods

    public static List<Sessions> GetAll()
    {
        //List<Week> list = new List<Week>();
        //list.Add(new Week(1, new DateTime(2022 - 10 - 9), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 16), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 23), 0));
        //return list;

        SqlCommand command = new SqlCommand(select);
        return SessionsMapper.ToList(SqlServerConnection.ExecuteQuery(command));
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

