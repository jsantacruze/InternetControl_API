using System.Linq;
using System.Security.Claims;
using business_layer.IdentitySecurity.Contracts;
using Microsoft.AspNetCore.Http;

namespace security_layer.JWTTokenSecurity
{
    public class SessionUser : ISessionUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionUser(IHttpContextAccessor httpContextAccessor){
            _httpContextAccessor = httpContextAccessor;
        }
        public string getSessionUser()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}