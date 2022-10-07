using Ardalis.GuardClauses;
using Splatrika.BronyMusicBrowser.Core.Entities.SongJoins;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Entities;

#nullable disable

public class Song : EntityBase, IAggregationRoot
{
    public string Title { get; private set; }
    public string Cover { get; private set; }
    public int Year { get; private set; }
    public string YouTubeId { get; private set; }
    public IReadOnlyCollection<SongArtist> Artists => _artists.AsReadOnly();
    public IReadOnlyCollection<SongGenre> Genres => _genres.AsReadOnly();
    public IReadOnlyCollection<SongCharacter> Characters
        => _characters.AsReadOnly();


    private List<SongArtist> _artists;
    private List<SongGenre> _genres;
    private List<SongCharacter> _characters;


    public Song(int id, string title, string cover, int year, string youTubeId)
        : base(id)
    {
        UpdateDetails(title, year, youTubeId, cover);
        _artists = new();
        _genres = new();
        _characters = new();
    }


    public void UpdateDetails(string title, int year, string youTubeId,
        string cover)
    {
        Title = Guard.Against.NullOrEmpty(title);
        Year = Guard.Against.Negative(year);
        YouTubeId = Guard.Against.NullOrEmpty(youTubeId);
        Cover = cover;
    }


    public void AddArtist(int artistId)
    {
        SongArtist adding = new(Id, artistId);
        ListGuard.CannotAddDublicate(_artists, adding);
        _artists.Add(adding);
    }


    public void RemoveArtist(int artistId)
    {
        SongArtist removing = new(Id, artistId);
        ListGuard.CannotRemoveNonexistent(_artists, removing);
        _artists.Remove(removing);
    }


    public void AddGenre(int genreId)
    {
        SongGenre adding = new(Id, genreId);
        ListGuard.CannotAddDublicate(_genres, adding);
        _genres.Add(adding);
    }


    public void RemoveGenre(int genreId)
    {
        SongGenre removing = new(Id, genreId);
        ListGuard.CannotRemoveNonexistent(_genres, removing);
        _genres.Remove(removing);
    }


    public void AddCharacter(int characterId)
    {
        SongCharacter adding = new(Id, characterId);
        ListGuard.CannotAddDublicate(_characters, adding);
        _characters.Add(adding);
    }


    public void RemoveCharacter(int characterId)
    {
        SongCharacter removing = new(Id, characterId);
        ListGuard.CannotRemoveNonexistent(_characters, removing);
        _characters.Remove(removing);
    }
}

