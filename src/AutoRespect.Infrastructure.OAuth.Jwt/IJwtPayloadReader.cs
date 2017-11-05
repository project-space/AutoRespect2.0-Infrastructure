using System;
using System.IdentityModel.Tokens.Jwt;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public interface IJwtPayloadReader
    {
        JwtPayload Read(string token);
    }

    [DI(LifeCycle.Singleton)]
    public class JwtPayloadReader : IJwtPayloadReader
    {
        public JwtPayload Read(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var payload      = tokenHandler.ReadJwtToken(token);

            return new JwtPayload
            {
                AccountId = Convert.ToInt32(payload.Payload["AccountId"])
            };
        }
    }
}
