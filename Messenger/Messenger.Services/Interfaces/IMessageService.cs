using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities.ChatEntities;

namespace Messenger.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetAll();
        Task<Message> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Message message);
        Task<bool> DeleteAsync(Message message);
        Task<bool> UpdateAsync(Message message);
    }
}
