using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;
using Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure.Builders;
using Xunit;

namespace Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure;

public class AlbumRepositoryTests : IDisposable
{
    private BrowserContext _context;
    private AlbumCrudRepository _repository;


    public AlbumRepositoryTests()
    {
        _context = BrowserContextBuilder.BuildTesting();
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();
        _repository = new(_context);
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }


    [Fact]
    public async Task GetById()
    {
        var album1 = new Album(0, 1, "Album1", "/img/cover1.png");
        var album2 = new Album(0, 1, "Album2", "/img/cover2.png");
        _context.AddRange(album1, album2);
        _context.SaveChanges();

        var album = await _repository.Get(id: 2);
        Assert.Equal(2, album.Id);
        Assert.Equal("Album2", album.Title);
        Assert.Equal("/img/cover2.png", album.Cover);
        Assert.Equal(1, album.Songs.Count);
    }


    [Fact]
    public async Task Create()
    {
        var album1 = new Album(0, 1, "Album1", "/img/cover1.png");
        _context.AddRange(album1);
        _context.SaveChanges();

        var album = await _repository
            .Create(new("Album101", "/img/cover1.png", 10));
        Assert.Equal(2, album.Id);
        Assert.Equal("Album101", album.Title);
        Assert.Equal("/img/cover1.png", album.Cover);
        Assert.Equal(1, album.Songs.Count);
    }


    [Fact]
    public async Task UpdateDetails()
    {
        var album1 = new Album(0, 1, "Album1", "/img/cover1.png");
        _context.Add(album1);
        _context.SaveChanges();

        var album = await _repository.Get(1);
        album.UpdateDetails("Album101", "/img/cover101.png");
        await _repository.SaveChanges();

        RebuildServices();
        album = await _repository.Get(1);
        Assert.Equal("Album101", album.Title);
        Assert.Equal("/img/cover101.png", album.Cover);
    }


    [Fact]
    public async Task AddSongs()
    {
        var album1 = new Album(0, 1, "Album1", "/img/cover1.png");
        _context.Add(album1);
        _context.SaveChanges();

        var album = await _repository.Get(id: 1);
        album.AddSong(2);
        album.AddSong(8);
        await _repository.SaveChanges();

        RebuildServices();
        album = await _repository.Get(id: 1);
        Assert.Equal(3, album.Songs.Count);
    }


    [Fact]
    public async Task RemoveSongs()
    {
        var album1 = new Album(0, 1, "Album1", "/img/cover1.png");
        album1.AddSong(10);
        _context.Add(album1);
        _context.SaveChanges();

        var album = await _repository.Get(id: 1);
        album.RemoveSong(10);
        await _repository.SaveChanges();

        RebuildServices();
        album = await _repository.Get(id: 1);
        Assert.Equal(1, album.Songs.Count);
    }


    [Fact]
    public async Task Contains()
    {
        var album1 = new Album(0, 1, "Album1", "/img/cover1.png");
        var album2 = new Album(0, 1, "Album1", "/img/cover1.png");
        var album3 = new Album(0, 1, "Album1", "/img/cover1.png");
        _context.AddRange(album1, album2, album3);
        _context.SaveChanges();

        Assert.True(await _repository.Contains(2));
        Assert.False(await _repository.Contains(0));
        Assert.False(await _repository.Contains(10));
    }


    private void RebuildServices()
    {
        _context.Dispose();
        _context = BrowserContextBuilder.BuildTesting();
        _repository = new(_context);
    }
}

