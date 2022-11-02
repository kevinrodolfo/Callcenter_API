

public class Config
{

    public SqlServer SqlServer { get; set; } = default!;
    public string Root { get; set; } = default!;
    public Files Files { get; set; } = default!;
    public Format Format { get; set; } = default!;

    public static Config Configuration = default!;


}

