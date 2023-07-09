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

        public Task<bool> CreateAsync(Dialog dialog)
        {
            if (dialog == null)
            {
                return Task.FromResult(false);
            }

            _context.Dialogs.Add(dialog);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> DeleteAsync(Dialog dialog)
        {
            if (dialog == null)
            {
                return Task.FromResult(false);
            }

            _context.Dialogs.Remove(dialog);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<Dialog> GetByIdAsync(Guid id)
        {
            return _context.Dialogs.FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<bool> UpdateAsync(Dialog dialog)
        {
            if (dialog == null)
            {
                return Task.FromResult(false);
            }

            _context.Dialogs.Update(dialog);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
