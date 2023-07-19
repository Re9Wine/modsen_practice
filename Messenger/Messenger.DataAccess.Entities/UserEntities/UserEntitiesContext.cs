using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Entities.UserEntities
{
    public static class UserEntitiesContext
    {
        public static void UserModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasAlternateKey(x => x.Username);
                entity.HasAlternateKey(x => x.PhoneNumber);
            });

            modelBuilder.Entity<UserContact>(entity =>
            {
                entity.ToTable("UserContact");

                entity.HasKey(x => new { x.ContactID, x.UserID });

                entity.HasOne(d => d.ContactUser)
                   .WithMany(p => p.UserContacts)
                   .HasForeignKey(d => d.ContactID)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_UserContacts_Contact");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInContacts)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserContacts_User");
            });
        }
    }
}
