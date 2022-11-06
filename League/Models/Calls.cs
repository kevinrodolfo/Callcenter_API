using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
public class Calls
{

    #region sql statements
    private static string select = "select callId, phoneNumber, dateTimeReceived, dateTimeAnswered, dateTimeEnded, timeinQueue, timeInCall, idStatus, callStatus, idAgent, name, idStation from viewCalls";
    #endregion

    #region attributes
    private int _callId;
    private string _phoneNumber;
    private DateTime _dateTimeReceived;
    private DateTime _dateTimeAnswered;
    private DateTime _dateTimeEnded;
    private TimeSpan _timeInQueue;
    private TimeSpan _timeInCall;
    private int _idStatus;
    private string _callStatus;
    private int _idAgent;
    private string _name;
    private int _idStation;
    #endregion

    #region properties
    public int CallId { get => _callId; set => _callId = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public DateTime DateTimeReceived { get => _dateTimeReceived; set => _dateTimeReceived = value; }
    public DateTime DateTimeAnswered { get => _dateTimeAnswered; set => _dateTimeAnswered = value; }
    public DateTime DateTimeEnded { get => _dateTimeEnded; set => _dateTimeEnded = value; }
    public TimeSpan TimeInQueue { get => _timeInQueue; set => _timeInQueue = value; }
    public TimeSpan TimeInCall { get => _timeInCall; set => _timeInCall = value; }
    public int IdStatus { get => _idStatus; set => _idStatus = value; }
    public string CallStatus { get => _callStatus; set => _callStatus = value; }
    public int IdAgent { get => _idAgent; set => _idAgent = value; }
    public string Name { get => _name; set => _name = value; }
    public int IdStation { get => _idStation; set => _idStation = value; }
    



    #endregion

    #region constructors

    public Calls()
    {
        _callId = 0;
        _phoneNumber = "";
        _dateTimeReceived = new DateTime();
        _dateTimeAnswered = new DateTime();
        _dateTimeEnded = new DateTime();
        _timeInQueue = new TimeSpan();
        _timeInCall = new TimeSpan();
        _idStatus = 0;
        _callStatus = "";
        _idAgent = 0;
        _name = "";
        _idStation = 0;
    }

    public Calls(int callId, string phoneNumber, DateTime dateTimeReceived, DateTime dateTimeAnswered, DateTime dateTimeEnded, TimeSpan timeInQueue, TimeSpan TimeInCall, int idStatus, string callStatus, int idAgent, string name, int idStation)
    {
        _callId = callId;
        _phoneNumber = phoneNumber;
        _dateTimeReceived = dateTimeReceived;
        _dateTimeAnswered = dateTimeAnswered;
        _dateTimeEnded = dateTimeEnded;
        _timeInQueue = timeInQueue;
        _timeInCall = TimeInCall;
        _idStatus = idStatus;
        _callStatus = callStatus;
        _idAgent = idAgent;
        _name = name;
        _idStation = idStation;
    }

    #endregion

    #region instance methods

    public static List<Calls> GetAll()
    {
        //List<Week> list = new List<Week>();
        //list.Add(new Week(1, new DateTime(2022 - 10 - 9), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 16), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 23), 0));
        //return list;

        SqlCommand command = new SqlCommand(select);
        return CallsMapper.ToList(SqlServerConnection.ExecuteQuery(command));
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

