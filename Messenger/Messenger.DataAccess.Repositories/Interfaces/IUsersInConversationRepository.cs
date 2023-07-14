using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IUsersInConversationRepository : IBaseRepository<UsersInConversation>
    {
        Task<UsersInConversation> GetByIdAsync(Guid conversationID, Guid userID);
    }
}
