using System.Security.Principal;

namespace webapilab.crosscutting
{
    public interface ICustomPrincipal : IPrincipal
    {
        UserContext UserContext { get; set; }
    }
}