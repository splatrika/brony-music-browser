using Microsoft.EntityFrameworkCore;
using Moq;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;
using Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure.Builders;
using Splatrika.BronyMusicBrowser.Tests.Unit.Core.Builders;
using Xunit;

namespace Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure;

public class ReadOnlySongRepositoryTests : IDisposable
{
    private BrowserContext _context;
    private IReadOnlySongRepository _repository;
    private SongFilters? _queryFilters;


    public ReadOnlySongRepositoryTests()
    {
        _context = BrowserContextBuilder.BuildTesting();
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();
        _repository = new ReadOnlySongRepository(_context,
            GetFakeFiltersProvider());
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }


    [Fact]
    public async Task GetShortInfo()
    {
        var song1 = new SongBuilder()
            .SetTitle("Song0")
            .Build();
        var song2 = new SongBuilder()
            .SetTitle("The Magic Flicker")
            .AddArtist(1)
            .AddArtist(2)
            .Build();
        var artist1 = new Artist(0, "Artist1");
        var artist2 = new Artist(0, "Artist2");
        _context.AddRange(artist1, artist2, song1, song2);
        _context.SaveChanges();

        var song = await _repository.GetShort(id: 2);
        Assert.Equal("The Magic Flicker", song.Title);
        Assert.True(song.Artists
            .SequenceEqual(new[] { 1, 2 }));
    }


    [Fact]
    public async Task GetByFilters()
    {
        var song1 = new SongBuilder().Build();
        var song2 = new SongBuilder()
            .SetTitle("Song101")
            .SetYouTubeId("???")
            .Build();
        var song3 = new SongBuilder().Build();
        var song4 = new SongBuilder()
            .SetTitle("Song101")
            .SetYouTubeId("???")
            .Build();
        var song5 = new SongBuilder()
            .SetTitle("Song101")
            .SetYouTubeId("???")
            .Build();
        var song6 = new SongBuilder().Build();
        _context.AddRange(song1, song2, song3, song4, song5);
        _context.SaveChanges();

        var filters = new SongFilters();
        var page1 = await _repository.GetByFilters(filters, 2, 0);
        var page2 = await _repository.GetByFilters(filters, 2, 2);

        Assert.Equal(_queryFilters, filters);
        Assert.Equal(2, page1.Count);
        Assert.Single(page2);
        Assert.True(page1.Select(x => x.Id)
            .SequenceEqual(new[] { 2, 4 }));
        Assert.True(page2.Select(x => x.Id)
            .SequenceEqual(new[] { 5 }));
    }


    private IFilterProcessorsProvider<Song, SongFilters>
        GetFakeFiltersProvider()
    {
        var mock = new Mock<IFilterProcessorsProvider<Song, SongFilters>>();

        var filter1Mock = new Mock<IFilterProcessor<Song, SongFilters>>();
        var filter2Mock = new Mock<IFilterProcessor<Song, SongFilters>>();

        filter1Mock.Setup(m => m.ApplyFilter(
            It.IsAny<IQueryable<Song>>(),
            It.IsAny<SongFilters>()))
            .Callback<IQueryable<Song>, SongFilters>(
                (query, filters) => _queryFilters = filters )
            .Returns<IQueryable<Song>, SongFilters>(
                (query, filters) => query.Where(e => e.Title == "Song101"));

        filter2Mock.Setup(m => m.ApplyFilter(
            It.IsAny<IQueryable<Song>>(),
            It.IsAny<SongFilters>()))
            .Returns<IQueryable<Song>, SongFilters>(
                (query, filters) => query.Where(e => e.YouTubeId == "???"));

        mock.Setup(m => m.Get())
            .Returns(new[] { filter1Mock.Object, filter2Mock.Object });

        return mock.Object;
    }
}

