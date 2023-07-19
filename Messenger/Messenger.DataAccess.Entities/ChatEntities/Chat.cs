using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Messenger.DataAccess.Entities.ChatEntities
{
    public class Chat : BaseEntity
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
        }

        [Required]
        public ChatType ChatType { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public virtual ICollection<Message> Messages { get; set; }
    }

    public enum ChatType
    {
        Dialog = 0,
        Conversation,
        Channel,
    }
}
