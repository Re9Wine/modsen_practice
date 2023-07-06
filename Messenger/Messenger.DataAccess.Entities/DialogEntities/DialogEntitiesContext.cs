using Microsoft.EntityFrameworkCore;
using Messenger.DataAccess.Entities.UserEntities;

namespace Messenger.DataAccess.Entities.DialogEntities
{
    public static class DialogEntitiesContext
    {
        public static void DialogModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("Conversation");

                entity.Property(e => e.ID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dialog>(entity =>
            {
                entity.ToTable("Dialog");

                entity.Property(e => e.ID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.FirstUserID)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FirstUserID");

                entity.Property(e => e.SecondUserID)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SecondUserID");

                entity.HasOne(d => d.FirstUser)
                    .WithMany(p => p.Dialogs)
                    .HasForeignKey(d => d.FirstUserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dialog_User");

                entity.HasOne(d => d.SecondUser)
                    .WithMany(p => p.Dialogs)
                    .HasForeignKey(d => d.SecondUserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dialog_User1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.ID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.DialogID)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DialogID");

                entity.Property(e => e.SenderID)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SenderID");

                entity.Property(e => e.SendingDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.DialogID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Conversation");

                entity.HasOne(d => d.Dialog)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.DialogID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Dialog");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SenderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<UsersInConversation>(entity =>
            {
                entity.HasKey(e => new { e.ConversationID, e.UserID });

                entity.ToTable("UsersInConversation");

                entity.Property(e => e.ConversationID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ConversationID");

                entity.Property(e => e.UserID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.UsersInConversation)
                    .HasForeignKey(d => d.ConversationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInConversation_Conversation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInConversation_User");
            });
        }
    }
}
