using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class SongArtistConfifuration : IEntityTypeConfiguration<SongArtist>
{
    public void Configure(EntityTypeBuilder<SongArtist> builder)
    {
        builder.HasKey(e => new { e.SongId, e.ArtistId });
        builder.HasIndex(e => e.SongId);

        builder.HasOne<Artist>()
            .WithMany()
            .HasForeignKey(e => e.ArtistId);
    }
}

