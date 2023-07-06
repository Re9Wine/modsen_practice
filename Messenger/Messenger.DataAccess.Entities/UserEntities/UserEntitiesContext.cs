using Microsoft.EntityFrameworkCore;
using Messenger.DataAccess.Entities.DialogEntities;

namespace Messenger.DataAccess.Entities.UserEntities
{
    public static class UserEntitiesContext
    {
        public static void UserModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4FA2452F0")
                    .IsUnique();

                entity.Property(e => e.PhoneNumber)
                    .ValueGeneratedNever();

                entity.Property(e => e.AboutSelf)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserContact>(entity =>
            {
                entity.HasKey(e => new { e.UserID, e.ContactID });

                entity.Property(e => e.UserID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.ContactID)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ContactID");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContactUser)
                    .WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_User");
            });
        }
    }
}
