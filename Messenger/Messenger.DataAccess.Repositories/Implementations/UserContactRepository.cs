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
        private readonly MessengerContext _context;

        public UserContactRepository(MessengerContext context)
        {
            _context = context;
        }

        public Task<bool> CreateAsync(UserContact userContact)
        {
            if (userContact == null)
            {
                return Task.FromResult(false);
            }

            _context.UserContacts.Add(userContact);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> DeleteAsync(UserContact userContact)
        {
            if (userContact == null)
            {
                return Task.FromResult(false);
            }

            _context.UserContacts.Remove(userContact);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<UserContact> GetByIdAsync(Guid userID, Guid contactID)
        {
            return _context.UserContacts.FirstOrDefaultAsync(x => x.UserID == userID && x.ContactID == contactID);
        }

        public Task<bool> UpdateAsync(UserContact userContact)
        {
            if (userContact == null)
            {
                return Task.FromResult(false);
            }

            _context.UserContacts.Update(userContact);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
