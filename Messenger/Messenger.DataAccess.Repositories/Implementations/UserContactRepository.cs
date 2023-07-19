using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.UserEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class UserContactRepository : IUserContactRepository
    {
        private readonly MessangerDbContext _context;

        public UserContactRepository(MessangerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(UserContact entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UserContacts.Add(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(UserContact entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UserContacts.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<UserContact> GetByIdAsync(Guid userID, Guid contactID)
        {
            return await _context.UserContacts.FirstOrDefaultAsync(x =>
                x.ContactID == contactID && x.UserID == userID);
        }

        public async Task<bool> UpdateAsync(UserContact entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.UserContacts.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
