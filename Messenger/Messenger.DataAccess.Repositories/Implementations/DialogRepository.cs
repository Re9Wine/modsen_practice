using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities.DialogEntities;
using Messenger.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Implementations
{
    public class DialogRepository : IDialogRepository
    {
        private readonly MessengerContext _context;

        public DialogRepository(MessengerContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Dialog entity)
        {
            if (entity == null)
            {
                return false;
            }

            await _context.Dialogs.AddAsync(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> DeleteAsync(Dialog entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Dialogs.Remove(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<Dialog> GetByIdAsync(Guid id)
        {
            return await _context.Dialogs.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<bool> UpdateAsync(Dialog entity)
        {
            if (entity == null)
            {
                return false;
            }

            _context.Dialogs.Update(entity);

            return (await _context.SaveChangesAsync()) != 0;
        }
    }
}
