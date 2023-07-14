using Messenger.DataAccess.Entities.UserEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUserContactRepository : IBaseRepository<UserContact>
    {
        Task<UserContact> GetByIdAsync(Guid userID, Guid contactID);
    }
}
