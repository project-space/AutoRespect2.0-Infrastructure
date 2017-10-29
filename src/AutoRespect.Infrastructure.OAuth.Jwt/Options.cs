using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public static class Options
    {
        public static string Issuer = "AutoRespect.AuthorizationServer";
        public static string Audience = "AutoRespect.ResourceServer";
        public static TimeSpan LifeTime = new TimeSpan(0, 1, 0);
        public static SymmetricSecurityKey SecretKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes("HIDE IN PRIVATE SETTINGS")); // TODO: 
    }
}
