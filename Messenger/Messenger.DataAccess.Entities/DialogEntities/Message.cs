using System;
using Messenger.DataAccess.Entities.UserEntities;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class Message
    {
        public Guid ID { get; set; }
        public Guid DialogID { get; set; }
        public Guid SenderID { get; set; }
        public DateTime SendingDate { get; set; }
        public string Text { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual Dialog Dialog { get; set; }
        public virtual User Sender { get; set; }
    }
}
