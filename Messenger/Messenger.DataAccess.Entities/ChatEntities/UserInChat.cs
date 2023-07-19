using Messenger.DataAccess.Entities.UserEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.DataAccess.Entities.ChatEntities
{
    public class UserInChat
    {
        public Guid ChatID { get; set; }
        public Guid UserID { get; set; }


        [ForeignKey(nameof(ChatID))]
        public virtual Chat Chat { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }
    }
}
