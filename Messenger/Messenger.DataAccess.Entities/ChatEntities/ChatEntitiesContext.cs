using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Entities.ChatEntities
{
    public static class ChatEntitiesContext
    {
        public static void ChatModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");
            });

            modelBuilder.Entity<UserInChat>(entity =>
            {
                entity.ToTable("UserInChat");

                entity.HasKey(x => new { x.UserID, x.ChatID });
            });
        }
    }
}
