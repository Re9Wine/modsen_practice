using Messenger.DataAccess.Entities.ChatEntities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<Message> GetByIdAsync(Guid id);
        Task<List<Message>> GetAll();
    }
}
