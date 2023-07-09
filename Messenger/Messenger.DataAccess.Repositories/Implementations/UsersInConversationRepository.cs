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

        public Task<bool> CreateAsync(UsersInConversation usersInConversation)
        {
            if (usersInConversation == null)
            {
                return Task.FromResult(false);
            }

            _context.UsersInConversations.Add(usersInConversation);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> DeleteAsync(UsersInConversation usersInConversation)
        {
            if (usersInConversation == null)
            {
                return Task.FromResult(false);
            }

            _context.UsersInConversations.Remove(usersInConversation);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<UsersInConversation> GetByIdAsync(Guid conversationID, Guid userID)
        {
            return _context.UsersInConversations.FirstOrDefaultAsync(x => x.UserID == userID && x.ConversationID == conversationID);
        }

        public Task<bool> UpdateAsync(UsersInConversation usersInConversation)
        {
            if (usersInConversation == null)
            {
                return Task.FromResult(false);
            }

            _context.UsersInConversations.Update(usersInConversation);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
