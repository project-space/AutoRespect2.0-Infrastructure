using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutoRespect.Infrastructure.OAuth
{
    public class AuthorizationHeaderFromCookiesProvider
    {
        private readonly RequestDelegate next;

        public AuthorizationHeaderFromCookiesProvider(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("access-token", out var tokenFromCookies))
            {
                if (!context.Request.Headers.TryGetValue("Authorization", out var token))
                {
                    context.Request.Headers.Add("Authorization", $"Bearer {tokenFromCookies}");
                }
            }

            return next(context);
        }
    }
}
