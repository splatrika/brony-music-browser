using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.Tests.Unit.Core.Builders;

public class AlbumBuilder
{
    private string _title;
    private string _cover;
    private int _firstSong;
    private List<int> _songs;
    private List<int> _artists;


    public AlbumBuilder()
    {
        _title = "Album";
        _cover = "/cover.png";
        _firstSong = 1;
        _songs = new();
        _artists = new();
    }


    public AlbumBuilder SetTitle(string value)
    {
        _title = value;
        return this;
    }


    public AlbumBuilder SetCover(string value)
    {
        _cover = value;
        return this;
    }


    public AlbumBuilder SetFirstSong(int id)
    {
        _firstSong = id;
        return this;
    }


    public AlbumBuilder AddSong(int id)
    {
        _songs.Add(id);
        return this;
    }


    public AlbumBuilder AddArtist(int id)
    {
        _artists.Add(id);
        return this;
    }


    public Album Build()
    {
        var album = new Album(0, _firstSong, _title, _cover);
        foreach (var song in _songs)
        {
            album.AddSong(song);
        }
        foreach (var artist in _artists)
        {
            album.AddArtist(artist);
        }
        return album;
    }
}

