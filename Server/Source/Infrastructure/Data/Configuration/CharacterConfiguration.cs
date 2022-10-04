using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Configuration;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}

