using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class SongGenreConfiguration : IEntityTypeConfiguration<SongGenre>
{
    public void Configure(EntityTypeBuilder<SongGenre> builder)
    {
        builder.HasKey(e => new { e.SongId, e.GenreId });
        builder.HasIndex(e => e.SongId);

        builder.HasOne<Genre>()
            .WithMany()
            .HasForeignKey(e => e.GenreId);
    }
}

