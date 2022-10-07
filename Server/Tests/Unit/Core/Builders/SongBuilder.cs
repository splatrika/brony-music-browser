using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Tests.Unit.Core.Builders;

public class SongBuilder
{
    private string _title;
    private string _cover;
    private int _year;
    private string _youTubeId;
    private List<int> _artists;
    private List<int> _genres;
    private List<int> _characters;


    public SongBuilder()
    {
        _title = "Just a song";
        _cover = "/jus-a-cover.png";
        _year = 0;
        _youTubeId = "0";
        _artists = new();
        _genres = new();
        _characters = new();
    }


    public SongBuilder SetTitle(string value)
    {
        _title = value;
        return this;
    }


    public SongBuilder SetCover(string value)
    {
        _cover = value;
        return this;
    }


    public SongBuilder SetYer(int value)
    {
        _year = value;
        return this;
    }


    public SongBuilder SetYouTubeId(string value)
    {
        _youTubeId = value;
        return this;
    }


    public SongBuilder AddArtist(int id)
    {
        _artists.Add(id);
        return this;
    }


    public SongBuilder AddGenres(int id)
    {
        _genres.Add(id);
        return this;
    }


    public SongBuilder AddCharacter(int id)
    {
        _characters.Add(id);
        return this;
    }


    public Song Build()
    {
        var song = new Song(0, _title, _cover, _year, _youTubeId);
        foreach (var artist in _artists)
        {
            song.AddArtist(artist);
        }
        foreach (var genre in _genres)
        {
            song.AddGenre(genre);
        }
        foreach (var character in _characters)
        {
            song.AddCharacter(character);
        }
        return song;
    }
}

