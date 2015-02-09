using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using webapilab.crosscutting;
using webapilab.Models;

namespace webapilab.services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
        Task<IdentityUser> FindAsync(UserLoginInfo loginInfo);
        Task<IdentityResult> CreateAsync(UserContext user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        void Dispose();
    }
}