using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data;

#nullable disable

public class BrowserContext : DbContext
{
    public virtual DbSet<Song> Songs { get; set; }
    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Character> Characters { get; set; }
    public virtual DbSet<SongArtist> SongArtists { get; set; }
    public virtual DbSet<SongGenre> SongGenres { get; set; }
    public virtual DbSet<SongCharacter> SongCharacters { get; set; }
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<AlbumSong> AlbumSongs { get; set; }
    public virtual DbSet<AlbumArtist> AlbumArtists { get; set; }


    public BrowserContext(DbContextOptions<BrowserContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            typeof(BrowserContext).Assembly);
    }
}

