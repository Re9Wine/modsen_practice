using Messenger.DataAccess.Entities.UserEntities;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class UsersInConversation
    {
        public string ConversationID { get; set; }
        public int UserID { get; set; }

        public virtual Conversation Conversation { get; set; }
        public virtual User User { get; set; }
    }
}
