using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ErrorHandling;
using Microsoft.IdentityModel.Tokens;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public interface IJwtIssuer
    {
        Result<string> Release(JwtPayload payload);
    }

    [DI(LifeCycle.Singleton)]
    public class JwtIssuer : IJwtIssuer
    {
        public Result<string> Release(JwtPayload payload)
        {
            var identity = CreateClaims(payload);

            var jwt = new JwtSecurityToken(
                issuer: Options.Issuer,
                audience: Options.Audience,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(Options.LifeTime),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(Options.SecretKey, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private ClaimsIdentity CreateClaims(JwtPayload payload)
        {
            var claims = new List<Claim>()
            {
                new Claim ("AccountId", payload.AccountId.ToString())
            };

            return new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );
        }
    }
}
