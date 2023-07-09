using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.UserEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MessengerContext _context;

        public UserRepository(MessengerContext context)
        {
            _context = context;
        }

        public Task<bool> CreateAsync(User user)
        {
            if (user == null)
            {
                return Task.FromResult(false);
            }

            _context.Users.Add(user);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> DeleteAsync(User user)
        {
            if (user == null)
            {
                return Task.FromResult(false);
            }

            _context.Users.Remove(user);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<bool> UpdateAsync(User user)
        {
            if (user == null)
            {
                return Task.FromResult(false);
            }

            _context.Users.Update(user);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
