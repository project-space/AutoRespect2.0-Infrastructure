using Microsoft.AspNetCore.Builder;

namespace AutoRespect.Infrastructure.OAuth
{
    public static class AuthenticationApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAutoRespectJwtAuthentication(this IApplicationBuilder applicationBuilder) =>
            applicationBuilder
                .UseMiddleware<AuthorizationHeaderFromCookiesProvider>()
                .UseAuthentication();
    }
}
