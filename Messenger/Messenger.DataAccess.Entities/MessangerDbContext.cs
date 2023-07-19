using Messenger.DataAccess.Entities.ChatEntities;
using Messenger.DataAccess.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Entities
{
    public class MessangerDbContext : DbContext
    {
        public MessangerDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public MessangerDbContext(DbContextOptions<MessangerDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserInChat> UsersInChat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Messenger;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ChatModelCreating();
            modelBuilder.UserModelCreating();
        }
    }
}
