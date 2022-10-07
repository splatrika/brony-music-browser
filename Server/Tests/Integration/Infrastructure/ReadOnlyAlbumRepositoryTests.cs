using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;
using Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure.Builders;
using Splatrika.BronyMusicBrowser.Tests.Unit.Core.Builders;
using Xunit;

namespace Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure;

public class ReadOnlyAlbumRepositoryTests : IDisposable
{
    private BrowserContext _context;
    private IReadOnlyAlbumRepository _repository;


    public ReadOnlyAlbumRepositoryTests()
    {
        _context = BrowserContextBuilder.BuildTesting();
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();
        _repository = new ReadOnlyAlbumRepository(_context);
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }


    [Fact]
    public async Task GetBySong()
    {
        var album1 = new AlbumBuilder()
            .SetFirstSong(10)
            .AddSong(12)
            .Build();
        var album2 = new AlbumBuilder()
            .SetFirstSong(88)
            .AddSong(12)
            .Build();
        var album3 = new AlbumBuilder()
            .SetFirstSong(88)
            .Build();
        _context.AddRange(album1, album2, album3);
        _context.SaveChanges();

        var found1 = await _repository.GetFirstForSong(88);
        var found2 = await _repository.GetFirstForSong(100);
        Assert.NotNull(found1);
        Assert.Equal(2, found1!.Id);
        Assert.Null(found2);
    }


    [Fact]
    public async Task GetTitle()
    {
        var album1 = new AlbumBuilder()
            .Build();
        var album2 = new AlbumBuilder()
            .SetTitle("Glimmer Time")
            .Build();
        _context.AddRange(album1, album2);
        _context.SaveChanges();

        var album = await _repository.GetTitle(id: 2);
        Assert.Equal(2, album.Id);
        Assert.Equal("Glimmer Time", album.Title);
    }


    [Fact]
    public async Task GetById()
    {
        var album1 = new AlbumBuilder()
            .Build();
        var album2 = new AlbumBuilder()
            .SetTitle("Glimmer Time")
            .Build();
        _context.AddRange(album1, album2);
        _context.SaveChanges();

        var album = await _repository.Get(id: 2);
        Assert.Equal(2, album.Id);
        Assert.Equal("Glimmer Time", album.Title);
        Assert.Equal(1, album.Songs.Count);
    }


    [Fact]
    public async Task GetAll()
    {
        var album1 = new AlbumBuilder().Build();
        var album2 = new AlbumBuilder().Build();
        var album3 = new AlbumBuilder().Build();
        var album4 = new AlbumBuilder().Build();
        var album5 = new AlbumBuilder().Build();
        _context.AddRange(album1, album2, album3, album4, album5);
        _context.SaveChanges();

        var page1 = await _repository.GetAll(count: 3, offset: 0);
        var page2 = await _repository.GetAll(count: 3, offset: 3);
        Assert.Equal(3, page1.Count);
        Assert.Equal(2, page2.Count);
        Assert.True(page1.Select(x => x.Id)
            .SequenceEqual(new int[] { 1, 2, 3 }));
        Assert.True(page2.Select(x => x.Id)
            .SequenceEqual(new int[] { 4, 5 }));
    }
}

