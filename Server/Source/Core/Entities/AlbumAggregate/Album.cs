using Ardalis.GuardClauses;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

#nullable disable

public class Album : EntityBase, IAggregationRoot
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


#pragma warning disable IDE0051
    //Required by EF Core
    private Album(int id, string title, string cover) : base(id)
    {
        UpdateDetails(title, cover);
    }
#pragma warning restore IDE0051


    public void UpdateDetails(string title, string cover)
    {
        Title = Guard.Against.NullOrEmpty(title);
        Cover = cover;
    }


    public void AddSong(int songId)
    {
        var adding = new AlbumSong(Id, songId);
        ListGuard.CannotAddDublicate(_songs, adding);
        _songs.Add(adding);
    }


    public void RemoveSong(int songId)
    {
        var removing = new AlbumSong(Id, songId);
        ListGuard.CannotBeEmptyAfterRemove(_songs);
        ListGuard.CannotRemoveNonexistent(_songs, removing);
        _songs.Remove(removing);
    }


    public void AddArtist(int artistId)
    {
        var adding = new AlbumArtist(Id, artistId);
        ListGuard.CannotAddDublicate(_artists, adding);
        _artists.Add(adding);
    }


    public void RemoveArtist(int artistId)
    {
        var removing = new AlbumArtist(Id, artistId);
        ListGuard.CannotRemoveNonexistent(_artists, removing);
        _artists.Remove(removing);
    }
}

