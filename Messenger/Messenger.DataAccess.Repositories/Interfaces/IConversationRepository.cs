using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IConversationRepository : IBaseRepository<Conversation>
    {
        Task<Conversation> GetByIdAsync(Guid id);
    }
}
