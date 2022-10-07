using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;
using Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure.Builders;
using Splatrika.BronyMusicBrowser.Tests.Unit.Core.Builders;
using Splatrika.BronyMusicBrowser.Tests.Unit.Extensions;
using Xunit;

namespace Splatrika.BronyMusicBrowser.Tests.Integration.Infrastructure.SongFilterProcessors;

public class FilterByGenresTest : IDisposable
{
    private BrowserContext _context;


    public FilterByGenresTest()
    {
        _context = BrowserContextBuilder.BuildTesting();
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();

        var genre1 = new Genre(id: 0, caption: "Genre1", order: 0);
        var genre2 = new Genre(id: 0, caption: "Genre2", order: 0);
        var genre3 = new Genre(id: 0, caption: "Genre3", order: 0);
        _context.AddRange(genre1, genre2, genre3);
        _context.SaveChanges();
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }


    [Fact]
    public void FilterByGenres()
    {
        var song1 = new SongBuilder()
            .AddGenres(2)
            .Build();
        var song2 = new SongBuilder()
            .AddGenres(1)
            .Build();
        var song3 = new SongBuilder()
            .AddGenres(3)
            .AddGenres(2)
            .Build();
        _context.AddRange(song1, song2, song3);
        _context.SaveChanges();

        var filters = new SongFilters { Genres = new() { 2, 3 } };

        var query = new SongGenresProcessor()
            .ApplyFilter(_context.Songs, filters);

        var result = query.ToList();

        AssertExtensions.SequenceEqual(new[] { 1, 3 },
            result.Select(x => x.Id));
    }
}

