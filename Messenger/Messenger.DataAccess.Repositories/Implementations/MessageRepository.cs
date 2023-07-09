using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.DialogEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessengerContext _context;

        public MessageRepository(MessengerContext context)
        {
            _context = context;
        }

        public Task<bool> CreateAsync(Message message)
        {
            if (message == null)
            {
                return Task.FromResult(false);
            }

            _context.Messages.Add(message);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> DeleteAsync(Message message)
        {
            if (message == null)
            {
                return Task.FromResult(false);
            }

            _context.Messages.Remove(message);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<Message> GetByIdAsync(Guid id)
        {
            return _context.Messages.FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<bool> UpdateAsync(Message message)
        {
            if (message == null)
            {
                return Task.FromResult(false);
            }

            _context.Messages.Update(message);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
