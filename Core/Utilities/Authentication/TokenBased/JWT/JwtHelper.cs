using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Authentication.TokenBased.JWT
{
    public class JwtHelper : TokenHelper
    {
        private readonly TokenOptions _tokenOptions;

        public JwtHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public override Token GetAccessToken(IEnumerable<Claim> claims)
        {
            var token = new Token { Expiration = DateTime.Now.AddMinutes(_tokenOptions.Expiration) };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claims,
                expires: token.Expiration,
                signingCredentials: signingCredentials,
                notBefore: DateTime.Now);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
