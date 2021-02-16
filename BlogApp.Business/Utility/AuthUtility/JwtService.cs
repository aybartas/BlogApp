using BlogApp.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Business.Utility.AuthUtility
{
    public class JwtService : IJwtService
    {

        /*
         * I would like to give a brief introduction about what i am really doing here
         * -- BuildJwtToken
         *      -  Create a security key by using the key i've determined
         *      - Create signingCredentials with this key and proposed algo
         *      - Create jwt security token and use my class JwtConfig to determine properties
         *      - Use my class Token to assign written token
         *      - return it
        */

        public Token BuildJwtToken(AppUser user)
        {

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(JwtConfig.JwtConfig.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials
                (securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(

                    issuer:JwtConfig.JwtConfig.Issuer,
                    
                    audience:JwtConfig.JwtConfig.Audience,
                    
                    claims: SetClaims(user),
                    
                    notBefore: DateTime.Now,

                    expires:DateTime.Now.AddMinutes(JwtConfig.JwtConfig.Expires),

                    signingCredentials: signingCredentials
                
                );

            Token jwtToken = new Token();


            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();


           jwtToken.JwtToken = jwtTokenHandler.WriteToken(jwtSecurityToken);

            return jwtToken;
        }

        protected List<Claim> SetClaims(AppUser user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            return claims;
        }


    }
}
