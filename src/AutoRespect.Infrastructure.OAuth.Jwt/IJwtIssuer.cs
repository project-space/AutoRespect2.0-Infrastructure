using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using Microsoft.IdentityModel.Tokens;

namespace AutoRespect.Infrastructure.OAuth.Jwt
{
    public interface IJwtIssuer
    {
        string Release(JwtClaims claims);
    }

    [DI(LifeCycle.Singleton)]
    public class JwtIssuer : IJwtIssuer
    {
        public string Release(JwtClaims claims)
        {
            var identity = CreateIdentity(claims);
            var jwt      = new JwtSecurityToken(
                issuer: JwtOptions.Issuer,
                audience: JwtOptions.Audience,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(JwtOptions.LifeTime),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(JwtOptions.SecretKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedJwt   = tokenHandler.WriteToken(jwt);

            return encodedJwt;
        }

        private ClaimsIdentity CreateIdentity(JwtClaims claims)
        {
            return new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim ("AccountId", claims.AccountId.ToString()),
                    new Claim (ClaimsIdentity.DefaultNameClaimType, claims.AccountLogin)
                },
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );
        }
    }
}
