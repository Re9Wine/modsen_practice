using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DataAccess.Entities.UserEntities;

namespace Messenger.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Authorize(User user);
    }
}
