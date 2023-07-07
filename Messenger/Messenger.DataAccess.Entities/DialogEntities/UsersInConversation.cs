using Messenger.DataAccess.Entities.UserEntities;
using System;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class UsersInConversation
    {
        public Guid ConversationID { get; set; }
        public Guid UserID { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual User User { get; set; }
    }
}
