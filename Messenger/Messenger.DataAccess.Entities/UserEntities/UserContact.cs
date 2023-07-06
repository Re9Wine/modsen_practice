using System;
using System.Collections.Generic;

#nullable disable

namespace Messenger.DataAccess.Entities.UserEntities
{
    public partial class UserContact
    {
        public int UserID { get; set; }
        public int ContactID { get; set; }
        public string ContactName { get; set; }

        public virtual User ContactUser { get; set; }
        public virtual User User { get; set; }
    }
}
