using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.Property(e => e.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Cover)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Navigation(e => e.Songs)
            .HasField("_songs")
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(e => e.Artists)
            .HasField("_artists")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

