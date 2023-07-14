using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.UserEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> CreateAsync(User entity)
        {
            if(entity == null)
            {
                return false;
            }

            await _context.Users.AddAsync(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(User entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Users.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Users.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
