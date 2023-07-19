using Messenger.DataAccess.Entities.ChatEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IChatRepository : IBaseRepository<Chat>
    {
        Task<Chat> GetByIdAsync(Guid id);
    }
}
