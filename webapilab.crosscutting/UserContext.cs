using Microsoft.AspNet.Identity.EntityFramework;

namespace webapilab.crosscutting
{
    public class UserContext : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}