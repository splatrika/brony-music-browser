using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class AlbumSongConfiguration : IEntityTypeConfiguration<AlbumSong>
{
    public void Configure(EntityTypeBuilder<AlbumSong> builder)
    {
        builder.HasKey(e => new { e.AlbumId, e.SongId });
    }
}

