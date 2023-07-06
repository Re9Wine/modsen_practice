using System.Collections.Generic;
using Messenger.DataAccess.Entities.DialogEntities;

#nullable disable

namespace Messenger.DataAccess.Entities.UserEntities
{
    public partial class User
    {
        public User()
        {
            Dialogs = new HashSet<Dialog>();
            Messages = new HashSet<Message>();
            UserContacts = new HashSet<UserContact>();
            Conversations = new HashSet<UsersInConversation>();
        }

        public string ID { get; set; }
        public int PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string AboutSelf { get; set; }

        public virtual ICollection<Dialog> Dialogs { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }
        public virtual ICollection<UsersInConversation> Conversations { get; set; }
    }
}
