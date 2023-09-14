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
    }
}
