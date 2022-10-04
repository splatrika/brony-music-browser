using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class AlbumArtistConfiguration : IEntityTypeConfiguration<AlbumArtist>
{
    public void Configure(EntityTypeBuilder<AlbumArtist> builder)
    {
        builder.HasKey(e => new { e.AlbumId, e.ArtistId });
    }
}

