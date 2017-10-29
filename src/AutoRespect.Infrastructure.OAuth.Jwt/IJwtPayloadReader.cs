using AutoRespect.Infrastructure.ErrorHandling;
using System;
using System.IdentityModel.Tokens.Jwt;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.DI.Design;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public interface IJwtPayloadReader
    {
        Result<JwtPayload> Read(string token);
    }

    [DI(LifeCycleType.Singleton)]
    public class JwtPayloadReader : IJwtPayloadReader
    {
        public Result<JwtPayload> Read(string token)
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
