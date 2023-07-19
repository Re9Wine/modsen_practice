using Messenger.DataAccess.Entities.ChatEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUserInChatRepository : IBaseRepository<UserInChat>
    {
        Task<UserInChat> GetByIdAsync(Guid chatID, Guid userID);
    }
}
