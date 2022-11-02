using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Date
{

    #region attributes

    private DateTime _value;
    #endregion


    #region properties

    public DateTime Value { get => _value; set => _value = value; }
    public string Formmatted { get => _value.ToString(Config.Configuration.Format.Date); }

    #endregion

    #region constructor

    public Date(DateTime date)
    {
        _value = date;
    }


    #endregion
}