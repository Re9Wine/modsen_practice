using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<Message> GetByIdAsync(Guid id);
    }
}
