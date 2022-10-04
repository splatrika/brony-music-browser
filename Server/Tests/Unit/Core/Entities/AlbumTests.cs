using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Xunit;

namespace Splatrika.BronyMusicBrowser.Tests.Unit.Core.Entities;

public class AlbumTests
{
    [Fact]
    public void Create()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");

        Assert.Equal(10, album.Id);
        Assert.Equal("Album1", album.Title);
        Assert.Equal(1, album.Songs.Count);
        Assert.Equal(0, album.Artists.Count);
        Assert.Equal(10, album.Songs.ElementAt(0).AlbumId);
        Assert.Equal(2, album.Songs.ElementAt(0).SongId);
    }


    [Fact]
    public void AddNewSong()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");
        album.AddSong(4);

        Assert.Equal(2, album.Songs.Count);
        Assert.Equal(10, album.Songs.ElementAt(1).AlbumId);
        Assert.Equal(4, album.Songs.ElementAt(1).SongId);
    }

    [Fact]
    public void AddSongThatAlreadyInAlbum()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");

        Assert.Throws<InvalidOperationException>(
            () => album.AddSong(2));
    }


    [Fact]
    public void RemoveSongWhenCountMoreThanOne()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");
        album.AddSong(3);
        album.RemoveSong(2);

        Assert.Equal(1, album.Songs.Count);
        Assert.Equal(3, album.Songs.First().SongId);
    }


    [Fact]
    public void RemoveSongWhenCountIsOne()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");

        Assert.Throws<InvalidOperationException>(
            () => album.RemoveSong(2));
    }


    [Fact]
    public void RemoveNonexistentSong()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");
        album.AddSong(12);

        Assert.Throws<InvalidOperationException>(
            () => album.RemoveSong(33));
    }


    [Fact]
    public void UpdateDetails()
    {
        var album = new Album(id: 10, firstSongId: 2, title: "Album1", cover: "/");
        album.UpdateDetails(title: "Album2", cover: "/cover.png");

        Assert.Equal("Album2", album.Title);
        Assert.Equal("/cover.png", album.Cover);
    }


    [Fact]
    public void AddArtist()
    {
        var album = new Album(id: 11, firstSongId: 2, title: "Album1", cover: "/");
        album.AddArtist(12);

        Assert.Equal(1, album.Artists.Count);
        Assert.Equal(11, album.Artists.First().AlbumId);
        Assert.Equal(12, album.Artists.First().ArtistId);
    }


    [Fact]
    public void RemoveArtist()
    {
        var album = new Album(id: 11, firstSongId: 2, title: "Album1", cover: "/");
        album.AddArtist(12);
        album.RemoveArtist(12);

        Assert.Equal(0, album.Artists.Count);
    }


    [Fact]
    public void RemoveNonexistentArtist()
    {
        var album = new Album(id: 11, firstSongId: 2, title: "Album1", cover: "/");

        Assert.Throws<InvalidOperationException>(
            () => album.RemoveArtist(2));
    }
}

