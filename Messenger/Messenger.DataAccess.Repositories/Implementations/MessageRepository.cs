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

        public async Task<bool> CreateAsync(Message entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _context.Messages.AddAsync(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(Message entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Messages.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<Message> GetByIdAsync(Guid id)
        {
            return await _context.Messages.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Message entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Messages.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
