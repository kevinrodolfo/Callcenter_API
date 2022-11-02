public class Field
{
    #region attributes
    private string _id;
    private string _name;
    #endregion

    #region properties
    public string Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }


    #endregion

    #region constructors
    public Field()
    {
        _id = "";
        _name = "";
    }

    public Field(string id, string name)
    {
        _id = id;
        _name = name;
    }
    #endregion

    #region instance methods

    public static List<Field> GetAll()
    {
        List<Field> list = new List<Field>();
        list.Add(new Field("MF", "Main Field"));
        list.Add(new Field("F2", "Field 2"));
        list.Add(new Field("F3", "Field 3"));


        return list;
    }

    #endregion

    #region class methods

    #endregion
}

