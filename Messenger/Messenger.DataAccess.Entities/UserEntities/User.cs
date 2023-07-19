using Messenger.DataAccess.Entities.ChatEntities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Messenger.DataAccess.Entities.UserEntities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserInContacts = new HashSet<UserContact>();
            UserContacts = new HashSet<UserContact>();
            Messages = new HashSet<Message>();
            UserInChats = new HashSet<UserInChat>();
        }

        [Required]
        [Phone]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText(true)]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]

        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string AboutSelf { get; set; }


        public virtual ICollection<UserContact> UserInContacts { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserInChat> UserInChats { get; set; }
    }
}
