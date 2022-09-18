using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Configuration
{
    public class WatchListConfiguration : IEntityTypeConfiguration<WatchList>
    {
        public void Configure(EntityTypeBuilder<WatchList> builder)
        {

            builder.Property(x => x.IsWatched)
                .IsRequired();

            builder.Property(x => x.MovieId)
                .IsRequired();

            builder.HasOne(x => x.Movie)
                .WithOne(x => x.WatchList)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.User)
                .WithOne(x => x.WatchList)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
