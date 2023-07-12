using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities.UserEntities;

namespace Messenger.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(User user);
        Task<bool> DeleteAsync(User user);
        Task<bool> UpdateAsync(User user);
    }
}
