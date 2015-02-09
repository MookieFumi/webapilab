using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace webapilab.crosscutting
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {   
        }

        public DbSet<UserContext> UsersContext { get; set; }
    }
}