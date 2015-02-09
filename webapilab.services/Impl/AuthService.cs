using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using webapilab.crosscutting;
using webapilab.Models;

namespace webapilab.services.Impl
{
    public class AuthService : IAuthService, IDisposable
    {
        private readonly AuthContext _authContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(AuthContext authContext, UserStore<IdentityUser> userStore)
        {
            _authContext = authContext;
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(authContext));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var userContext = new UserContext()
            {
                Name = userModel.Name,
                Surname = userModel.Surname,
                Email = userModel.EMail,
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(userContext, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _authContext.Dispose();
            _userManager.Dispose();
        }
    }
}