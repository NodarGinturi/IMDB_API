using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.UserName)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            //builder.HasOne(x => x.Movie)
            //    .WithMany(x => x.User)
            //    .HasForeignKey(x => x.Id)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasOne(x => x.SentEmailsForUsers)
                .WithOne(x => x.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.WatchList)
                .WithOne(x => x.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
