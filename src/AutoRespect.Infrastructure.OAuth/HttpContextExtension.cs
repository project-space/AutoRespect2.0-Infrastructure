using Microsoft.AspNetCore.Http;

namespace AutoRespect.Infrastructure.OAuth
{
    public static class HttpContextExtension
    {
        public static void SignIn(this HttpContext context, string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                context.Response.Cookies.Append("access-token", accessToken);
            }
        }

        public static void SignOut(this HttpContext context)
        {
            context.Response.Cookies.Delete("access-token");
        }
    }
}
