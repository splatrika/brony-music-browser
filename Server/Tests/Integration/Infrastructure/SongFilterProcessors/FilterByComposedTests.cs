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

public class FilterByComposedTests : IDisposable
{
    private BrowserContext _context;


    public FilterByComposedTests()
    {
        _context = BrowserContextBuilder.BuildTesting();
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();

        var character1 = new Character(id: 0, name: "Character1", icon: "/");
        var character2 = new Character(id: 0, name: "Character2", icon: "/");
        var genre1 = new Genre(id: 0, caption: "Genre1", order: 0);
        var genre2 = new Genre(id: 0, caption: "Genre2", order: 0);
        _context.AddRange(character1, character2, genre1, genre2);
        _context.SaveChanges();
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }


    [Fact]
    public void FilterByGenreAndCharacter()
    {
        var song1 = new SongBuilder()
            .AddGenres(2)
            .AddCharacter(1)
            .AddCharacter(2)
            .Build();
        var song2 = new SongBuilder()
            .AddGenres(1)
            .Build();
        var song3 = new SongBuilder()
            .AddGenres(2)
            .AddCharacter(1)
            .Build();
        _context.AddRange(song1, song2, song3);
        _context.SaveChanges();

        var filters = new SongFilters
        {
            Genres = new() { 2 },
            Characters = new() { 1 }
        };

        var query = new SongGenresProcessor()
            .ApplyFilter(_context.Songs, filters);
        query = new SongCharactersProcessor()
            .ApplyFilter(query, filters);

        var result = query.ToList();

        AssertExtensions.SequenceEqual(new[] { 1, 3 },
            result.Select(x => x.Id));
    }
}

