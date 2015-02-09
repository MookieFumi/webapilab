using Microsoft.AspNet.Identity.EntityFramework;
using webapilab.crosscutting;

namespace webapilab.Infrastructure
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {   
        }

        public System.Data.Entity.DbSet<UserContext> UsersContext { get; set; }
    }
}