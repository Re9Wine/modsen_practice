using Microsoft.EntityFrameworkCore;
using Messenger.DataAccess.Entities.UserEntities;
using Messenger.DataAccess.Entities.DialogEntities;

#nullable disable

namespace Messenger.DataAccess.Entities
{
    public partial class MessengerContext : DbContext
    {
        public MessengerContext()
        {
        }

        public MessengerContext(DbContextOptions<MessengerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Dialog> Dialogs { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserContact> UserContacts { get; set; }
        public virtual DbSet<UsersInConversation> UsersInConversation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Messenger;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.DialogModelCreating();
            modelBuilder.UserModelCreating();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
