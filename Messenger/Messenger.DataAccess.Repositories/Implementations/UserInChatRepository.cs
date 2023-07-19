using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.ChatEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class UserInChatRepository : IUserInChatRepository
    {
        private readonly MessangerDbContext _context;

        public UserInChatRepository(MessangerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(UserInChat entity)
        {
            if(entity == null)
            {
                return false;
            }

            _context.UsersInChat.Add(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(UserInChat entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UsersInChat.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<UserInChat> GetByIdAsync(Guid chatID, Guid userID)
        {
            return await _context.UsersInChat.FirstOrDefaultAsync(x =>
                x.ChatID == chatID && x.UserID == userID);
        }

        public async Task<bool> UpdateAsync(UserInChat entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UsersInChat.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
