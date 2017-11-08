using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public static class JwtOptions
    {
        public static string Issuer = "AutoRespect.AuthorizationServer";
        public static string Audience = "AutoRespect Projects";
        public static TimeSpan LifeTime = new TimeSpan(1, 0, 0);
        public static SymmetricSecurityKey SecretKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes("HIDE IN PRIVATE SETTINGS")); // TODO: 
    }
}
