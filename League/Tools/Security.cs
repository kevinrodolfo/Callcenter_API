using Callcenter.Enumerators;
using Callcenter.ViewModel;

public class Security
{
    public static bool ValidateToken(string username, string token)
    {
        if (token == "123456")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static ErrorResponse GetError(SecurityError error)
    {
        ErrorResponse err = new ErrorResponse();
        err.Status = (int)error;
        err.ErrorMessage = error.ToString();
        return err;
    }
}
