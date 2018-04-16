using CompanyLibrary.Website.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Services
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> GetCurrentUserAsync(HttpContext httpContext);
        Task<string> GetCurrentUserIdAsync(HttpContext httpContext);
    }
}
