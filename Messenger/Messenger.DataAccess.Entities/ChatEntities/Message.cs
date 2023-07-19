using Messenger.DataAccess.Entities.UserEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.DataAccess.Entities.ChatEntities
{
    public class Message : BaseEntity
    {
        public Guid ChatID { get; set; }

        public Guid SenderID { get; set; }

        [Required]
        public DateTime SendingDate => DateTime.Now;

        [Required]
        [StringLength(500)]
        public string Text { get; set; }


        [ForeignKey(nameof(SenderID))]
        public virtual User Sender { get; set; }

        [ForeignKey(nameof(ChatID))]
        public virtual Chat Chat { get; set; }
    }
}
