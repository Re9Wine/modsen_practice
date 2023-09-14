using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Services.Interfaces;
using Messenger.DataAccess.Repositories.Interfaces;
using Messenger.DataAccess.Entities.ChatEntities;

namespace Messenger.Services.Implementations
{
    class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Message>> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }

        public Task<Message> GetByIdAsync(Guid id)
        {
            var result = _repository.GetByIdAsync(id);

            return result;
        }

        public Task<bool> CreateAsync(Message message)
        {
            var result = _repository.CreateAsync(message);

            return result;
        }

        public Task<bool> UpdateAsync(Message message)
        {
            var result = _repository.UpdateAsync(message);

            return result;
        }

        public Task<bool> DeleteAsync(Message message)
        {
            var result = _repository.DeleteAsync(message);

            return result;
        }
    }
}
