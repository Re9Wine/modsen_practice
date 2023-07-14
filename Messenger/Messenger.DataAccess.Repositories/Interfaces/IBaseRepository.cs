using System.Threading.Tasks;

namespace Messenger.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
