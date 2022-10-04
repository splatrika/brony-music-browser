using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}

