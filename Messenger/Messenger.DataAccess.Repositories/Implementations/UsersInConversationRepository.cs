using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.DialogEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class UsersInConversationRepository : IUsersInConversationRepository
    {
        private readonly MessengerContext _context;

        public UsersInConversationRepository(MessengerContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(UsersInConversation entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _context.UsersInConversations.AddAsync(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(UsersInConversation entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UsersInConversations.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<UsersInConversation> GetByIdAsync(Guid conversationID, Guid userID)
        {
            return await _context.UsersInConversations.FirstOrDefaultAsync(x => 
                x.ConversationID == conversationID && x.UserID == userID);
        }

        public async Task<bool> UpdateAsync(UsersInConversation entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UsersInConversations.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
