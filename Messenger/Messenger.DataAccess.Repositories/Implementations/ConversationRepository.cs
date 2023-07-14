using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.DialogEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly MessengerContext _context;

        public ConversationRepository(MessengerContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Conversation entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _context.Conversations.AddAsync(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(Conversation entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Conversations.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<Conversation> GetByIdAsync(Guid id)
        {
            return await _context.Conversations.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Conversation entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Conversations.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
