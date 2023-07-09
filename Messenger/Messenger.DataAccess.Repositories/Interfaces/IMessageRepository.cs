using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Message message);
        Task<bool> DeleteAsync(Message message);
        Task<bool> UpdateAsync(Message message);
    }
}
