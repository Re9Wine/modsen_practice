using Messenger.DataAccess.Entities.DialogEntities;
using System;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IDialogRepository : IBaseRepository<Dialog>
    {
        Task<Dialog> GetByIdAsync(Guid id);
    }
}
