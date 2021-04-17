using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor __httpContextAccessor;
        public UserAccessor(IHttpContextAccessor _httpContextAccessor)
        {
            __httpContextAccessor = _httpContextAccessor;
        }

        public string GetUsername()
        {
            return __httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}