using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IConversationRepository
    {
        Task<Conversation> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Conversation conversation);
        Task<bool> UpdateAsync(Conversation conversation);
        Task<bool> DeleteAsync(Conversation conversation);
    }
}
