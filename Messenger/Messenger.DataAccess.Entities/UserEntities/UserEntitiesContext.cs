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
                entity.ToTable("User");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever();

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4FA2452F0")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__User__XD")
                    .IsUnique();

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
                entity.ToTable("UserContact");

                entity.HasKey(e => new { e.UserID, e.ContactID });

                entity.Property(e => e.UserID)
                    .HasColumnName("UserID");

                entity.Property(e => e.ContactID)
                    .HasColumnName("ContactID");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContactUser)
                    .WithMany(p => p.UserContacts) // TODO mb change name, ask mentor
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_Contact");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInContacts) // TODO mb change name, ask mentor
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_User");
            });
        }
    }
}
