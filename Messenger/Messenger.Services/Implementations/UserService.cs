using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Messenger.Services.Interfaces;
using Messenger.DataAccess.Repositories.Interfaces;
using Messenger.DataAccess.Entities.UserEntities;
using Messenger.Services.Options;

namespace Messenger.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<List<User>> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            var result =  _repository.GetByIdAsync(id);

            return result;
        }

        public Task<bool> CreateAsync(User user)
        {
            var result =  _repository.CreateAsync(user);

            return result;
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

        public Task<bool> UpdateAsync(User user)
        {
            var result = _repository.UpdateAsync(user);

            return result;
        }

        public Task<bool> DeleteAsync(User user)
        {
            var result = _repository.DeleteAsync(user);

            return result;
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
