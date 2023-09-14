using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Messenger.Services.Options;
using Messenger.DataAccess.Repositories.Interfaces;
using Messenger.DataAccess.Entities.UserEntities;

namespace Messenger.Services.Implementations
{
    class AuthenticationService
    {
        private readonly IUserRepository _repository;

        public AuthenticationService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Authorize(User user)
        {
            var identity = GetIdentity(user);

            if (identity == null)
            {
                return Task.FromResult("User doesn't exists");
            }

            var currentTime = DateTime.UtcNow;

            var token = new JwtSecurityToken(
                issuer: AuthenticationOptions.ISSUER,
                audience: AuthenticationOptions.AUDIENCE,
                notBefore: currentTime,
                claims: identity.Claims,
                expires: currentTime.AddMinutes(AuthenticationOptions.LIFETIME),
                signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(encodedToken);
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            var userIsExists = _repository.GetAll().Result.Contains(user);

            if (userIsExists)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
                };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }
    }
}
