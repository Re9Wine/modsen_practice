using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.ChatEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly MessangerDbContext _context;

        public ChatRepository(MessangerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Chat entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Chats.Add(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(Chat entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Chats.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<Chat> GetByIdAsync(Guid id)
        {
            return await _context.Chats.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Chat entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Chats.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
