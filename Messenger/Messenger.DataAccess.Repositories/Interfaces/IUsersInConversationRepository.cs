using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUsersInConversationRepository
    {
        Task<UsersInConversation> GetByIdAsync(Guid conversationID, Guid userID);
        Task<bool> CreateAsync(UsersInConversation usersInConversation);
        Task<bool> DeleteAsync(UsersInConversation usersInConversation);
        Task<bool> UpdateAsync(UsersInConversation usersInConversation);
    }
}
