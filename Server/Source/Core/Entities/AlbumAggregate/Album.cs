using Ardalis.GuardClauses;

namespace Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

#nullable disable

public class Album : EntityBase
{
    public string Title { get; private set; }
    public string Cover { get; private set; }
    public IReadOnlyCollection<AlbumSong> Songs => _songs.AsReadOnly();
    public IReadOnlyCollection<AlbumArtist> Artists => _artists.AsReadOnly();

    private List<AlbumSong> _songs;
    private List<AlbumArtist> _artists;


    public Album(int id, int firstSongId, string title, string cover) : base(id)
    {
        UpdateDetails(title, cover);
        _songs = new();
        _artists = new();
        AddSong(firstSongId);
    }


    private Album() { } //Required by EF Core


    public void UpdateDetails(string title, string cover)
    {
        Title = Guard.Against.NullOrEmpty(title);
        Cover = cover;
    }


    public void AddSong(int songId)
    {
        if (_songs.Any(x => x.SongId == songId))
        {
            throw new InvalidOperationException(
                $"There is already song with id {songId} in album");
        }
        _songs.Add(new(Id, songId));
    }


    public void RemoveSong(int songId)
    {
        if (_songs.Count == 1)
        {
            throw new InvalidOperationException("Unable to remove song " +
                "because album can't contains no songs");
        }
        if (!_songs.Any(x => x.SongId == songId))
        {
            throw new InvalidOperationException(
                $"There is no song with id {songId}");
        }
        _songs.Remove(_songs.First(x => x.SongId == songId));
    }


    public void AddArtist(int artistId)
    {
        if (_artists.Any(x => x.ArtistId == artistId))
        {
            throw new InvalidOperationException(
                $"There is already artist with id {artistId} in album");
        }
        _artists.Add(new(Id, artistId));
    }


    public void RemoveArtist(int artistId)
    {
        if (!_artists.Any(x => x.ArtistId == artistId))
        {
            throw new InvalidOperationException(
                $"There is no artist with id {artistId}");
        }
        _artists.Remove(_artists.First(x => x.ArtistId == artistId));
    }
}

