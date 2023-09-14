using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.ChatEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessangerDbContext _context;

        public MessageRepository(MessangerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAll()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<bool> CreateAsync(Message entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Messages.Add(entity);

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
