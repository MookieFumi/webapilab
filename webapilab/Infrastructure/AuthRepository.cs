using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using webapilab.crosscutting;
using webapilab.Models;

namespace webapilab.Infrastructure
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _context = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
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
            _context.Dispose();
            _userManager.Dispose();

        }
    }
}