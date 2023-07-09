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

        public Task<bool> CreateAsync(Conversation conversation)
        {
            if (conversation == null)
            {
                return Task.FromResult(false);
            }

            _context.Conversations.Add(conversation);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Conversation conversation)
        {
            if (conversation == null)
            {
                return Task.FromResult(false);
            }

            _context.Conversations.Remove(conversation);

            return Task.FromResult(true);
        }

        public Task<Conversation> GetByIdAsync(Guid id)
        {
            return _context.Conversations.FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<bool> UpdateAsync(Conversation conversation)
        {
            if (conversation == null)
            {
                return Task.FromResult(false);
            }

            _context.Conversations.Update(conversation);

            return Task.FromResult(true);
        }
    }
}
