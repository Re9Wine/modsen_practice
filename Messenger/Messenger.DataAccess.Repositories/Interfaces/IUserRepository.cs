using Messenger.DataAccess.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAll();
        Task<User> GetByIdAsync(Guid id);
    }
}
