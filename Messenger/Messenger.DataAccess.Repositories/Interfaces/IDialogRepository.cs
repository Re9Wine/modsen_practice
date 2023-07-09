using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IDialogRepository
    {
        Task<Dialog> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Dialog dialog);
        Task<bool> DeleteAsync(Dialog dialog);
        Task<bool> UpdateAsync(Dialog dialog);
    }
}
