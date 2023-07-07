using System;
using System.Collections.Generic;
using Messenger.DataAccess.Entities.UserEntities;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class Dialog
    {
        public Dialog()
        {
            Messages = new HashSet<Message>();
        }

        public Guid ID { get; set; }
        public Guid FirstUserID { get; set; }
        public Guid SecondUserID { get; set; }

        public virtual User FirstUser { get; set; }
        public virtual User SecondUser { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
