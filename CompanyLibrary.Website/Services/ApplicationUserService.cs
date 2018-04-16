using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyLibrary.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CompanyLibrary.Website.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManger)
        {
            _userManager = userManger;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync(HttpContext httpContext)
            => await _userManager.GetUserAsync(httpContext.User);

        public async Task<string> GetCurrentUserIdAsync(HttpContext httpContext)
        {
            var user = await GetCurrentUserAsync(httpContext);
            return user.Id;
        }
    }
}
