using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.Property(e => e.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Cover)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(e => e.YouTubeId)
            .HasMaxLength(11)
            .IsRequired();

        builder.Navigation(e => e.Artists)
            .HasField("_artists")
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(e => e.Genres)
            .HasField("_genres")
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(e => e.Characters)
            .HasField("_characters")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

