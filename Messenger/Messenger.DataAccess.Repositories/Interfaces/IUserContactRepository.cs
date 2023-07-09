using Messenger.DataAccess.Entities.UserEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUserContactRepository
    {
        Task<UserContact> GetByIdAsync(Guid userID, Guid contactID);
        Task<bool> CreateAsync(UserContact userContact);
        Task<bool> DeleteAsync(UserContact userContact);
        Task<bool> UpdateAsync(UserContact userContact);
    }
}
