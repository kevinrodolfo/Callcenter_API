using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Callcenter.Enumerators
{
    public enum SecurityError
    {
        MissingOrEmptySecurityHeaders = 500,
        InvalidToken = 501

    }
}
