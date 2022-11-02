using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
public class Week
{
    #region sql statements
    private static string select = "select id, date, status from weeks";
    #endregion
    #region attributes

    private int _id;
    private DateTime _date;
    private int _status;
    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public DateTime Date { get => _date; set => _date = value; }
    public string Status { get => ((Status)_status).ToString(); set => ((Status)_status).ToString(); }



    #endregion

    #region constructors

    public Week()
    {
        _id = 0;
        _date = new DateTime();
        _status = 0;
    }

    public Week(int id, DateTime date, int status)
    {
        _id = id;
        _date = date;
        _status = status;
    }

    #endregion

    #region instance methods

    public static List<Week> GetAll()
    {
        //List<Week> list = new List<Week>();
        //list.Add(new Week(1, new DateTime(2022 - 10 - 9), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 16), 2));
        //list.Add(new Week(1, new DateTime(2022 - 10 - 23), 0));
        //return list;

        SqlCommand command = new SqlCommand(select);
        return WeekMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }

    #endregion 
}