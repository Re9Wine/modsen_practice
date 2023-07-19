using System;
using System.ComponentModel.DataAnnotations;

namespace Messenger.DataAccess.Entities.UserEntities
{
    public class UserContact
    {
        public Guid UserID { get; set; }

        public Guid ContactID { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }


        public virtual User ContactUser { get; set; }
        public virtual User User { get; set; }
    }
}
