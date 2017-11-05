using System;
using System.IdentityModel.Tokens.Jwt;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Shared.Errors.Design;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public interface IJwtPayloadReader
    {
        R<JwtPayload> Read(string token);
    }

    [DI(LifeCycle.Singleton)]
    public class JwtPayloadReader : IJwtPayloadReader
    {
        public R<JwtPayload> Read(string token)
        {
            var payload = new JwtSecurityTokenHandler()
                .ReadJwtToken(token);

            return new JwtPayload
            {
                AccountId = Convert.ToInt32(payload.Payload["AccountId"])
            };
        }
    }
}
