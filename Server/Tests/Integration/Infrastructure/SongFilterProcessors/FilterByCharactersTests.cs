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

public class FilterByCharactersTests : IDisposable
{
    private BrowserContext _context;


    public FilterByCharactersTests()
    {
        _context = BrowserContextBuilder.BuildTesting();
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();

        var character1 = new Character(id: 0, name: "Character1", icon: "/");
        var character2 = new Character(id: 0, name: "Character2", icon: "/");
        var character3 = new Character(id: 0, name: "Character3", icon: "/");
        _context.AddRange(character1, character2, character3);
        _context.SaveChanges();
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }


    [Fact]
    public void FilterByCharacters()
    {
        var song1 = new SongBuilder()
            .AddCharacter(3)
            .Build();
        var song2 = new SongBuilder()
            .AddCharacter(1)
            .AddCharacter(2)
            .Build();
        var song3 = new SongBuilder()
            .AddCharacter(2)
            .Build();
        _context.AddRange(song1, song2, song3);
        _context.SaveChanges();

        var filters = new SongFilters { Characters = new() { 1, 2 } };

        var query = new SongCharactersProcessor()
            .ApplyFilter(_context.Songs, filters);

        var result = query.ToList();

        AssertExtensions.SequenceEqual(new[] { 2, 3 },
            result.Select(x => x.Id));
    }
}

