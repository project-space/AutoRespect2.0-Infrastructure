using System;
using System.Linq;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.OAuth.Design;
using Microsoft.AspNetCore.Http;

namespace AutoRespect.Infrastructure.OAuth
{
    [DI(LifeCycle.Scope)]
    public class AccountContext : IAccountContext
    {
        private HttpContext httpContext;

        public AccountContext(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        public bool IsAuthorized => httpContext.User.Identity.IsAuthenticated;

        public int Id => Convert.ToInt32(GetClaim("AccountId"));

        public string Login => httpContext.User.Identity.Name;


        private string GetClaim(string name)
        {
            var claim = httpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (claim != null)
            {
                return claim.Value;
            }

            throw new Exception($"Can't get claim with name [{name}]");
        }
    }
}
