using System;

#nullable disable

namespace Messenger.DataAccess.Entities.UserEntities
{
    public partial class UserContact
    {
        public Guid UserID { get; set; }
        public Guid ContactID { get; set; }
        public string ContactName { get; set; }

        public virtual User ContactUser { get; set; }
        public virtual User User { get; set; }
    }
}
