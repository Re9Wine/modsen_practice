using System.Collections.Generic;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Message>();
            UsersInConversation = new HashSet<UsersInConversation>();
        }

        public string ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UsersInConversation> UsersInConversation { get; set; }
    }
}
