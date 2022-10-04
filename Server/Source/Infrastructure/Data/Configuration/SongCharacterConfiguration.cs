using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class SongCharacterConfiguration
    : IEntityTypeConfiguration<SongCharacter>
{
    public void Configure(EntityTypeBuilder<SongCharacter> builder)
    {
        builder.HasKey(e => new { e.SongId, e.CharacterId });

        builder.HasOne<Song>()
            .WithOne()
            .HasForeignKey<SongCharacter>(e => e.SongId)
            .IsRequired();
    }
}

