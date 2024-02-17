using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api
{
    public class GoogleTokenValidator : ISecurityTokenValidator
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public GoogleTokenValidator()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; } = TokenValidationParameters.DefaultMaximumTokenSizeInBytes;

        public bool CanReadToken(string securityToken)
        {
            return _tokenHandler.CanReadToken(securityToken);
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {

            GoogleJsonWebSignature.Payload payload = null;

            var claims = new List<Claim>();

            try
            {
                payload = GoogleJsonWebSignature.ValidateAsync(securityToken,
                        new GoogleJsonWebSignature.ValidationSettings())
                    .Result; // here is where I delegate to Google to validate
            }
            catch (InvalidJwtException e)
            {
                Serilog.Log.Information(e.Message);
            }
            
            validatedToken = new JwtSecurityToken(securityToken);

            if (payload != null)
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, payload.Name));
                claims.Add(new Claim(ClaimTypes.Name, payload.Name));
                claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, payload.FamilyName));
                claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, payload.GivenName));
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, payload.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, payload.Subject));
                claims.Add(new Claim(JwtRegisteredClaimNames.Iss, payload.Issuer));
            }



            try
            {
                var principle = new ClaimsPrincipal();
                principle.AddIdentity(new ClaimsIdentity(claims, "Password"));
                return principle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }
    }
}
