using System.Security.Principal;
using System.Web.Security;

namespace webapilab.crosscutting
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public UserContext UserContext { get; set; }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(role))
            {
                return Roles.IsUserInRole(Identity.Name, role);
            }
            return false;
        }

    }
}