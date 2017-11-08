using AutoRespect.Infrastructure.OAuth.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AutoRespect.Infrastructure.OAuth
{
    public static class AuthenticationServiceCollectionExtensions
    {
        public static void AddAutoRespectJwtAuthentication(this IServiceCollection services)
        {
            //support for account context
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtOptions.Issuer,
                        ValidAudience = JwtOptions.Audience,
                        IssuerSigningKey = JwtOptions.SecretKey,
                        ValidateLifetime = true

                    };
                });
        }
    }
}
