using Messenger.DataAccess.Entities.UserEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(User user);
        Task<bool> DeleteAsync(User user);
        Task<bool> UpdateAsync(User user);
    }
}
