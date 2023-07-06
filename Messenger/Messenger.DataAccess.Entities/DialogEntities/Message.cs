using System;
using Messenger.DataAccess.Entities.UserEntities;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class Message
    {
        public string ID { get; set; }
        public string DialogID { get; set; }
        public string SenderID { get; set; }
        public DateTime SendingDate { get; set; }
        public string Text { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual Dialog Dialog { get; set; }
        public virtual User Sender { get; set; }
    }
}
