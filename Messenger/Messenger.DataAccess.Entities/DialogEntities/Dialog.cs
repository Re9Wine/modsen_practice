using System.Collections.Generic;
using Messenger.DataAccess.Entities.UserEntities;

#nullable disable

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public partial class Dialog
    {
        public Dialog()
        {
            Messages = new HashSet<Message>();
        }

        public string ID { get; set; }
        public string FirstUserID { get; set; }
        public string SecondUserID { get; set; }

        public virtual User FirstUser { get; set; }
        public virtual User SecondUser { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
