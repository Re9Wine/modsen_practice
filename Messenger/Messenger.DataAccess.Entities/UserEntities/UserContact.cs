using System;
using System.Collections.Generic;

#nullable disable

namespace Messenger.DataAccess.Entities.UserEntities
{
    public partial class UserContact
    {
        public string UserID { get; set; }
        public string ContactID { get; set; }
        public string ContactName { get; set; }

        public virtual User ContactUser { get; set; }
        public virtual User User { get; set; }
    }
}
