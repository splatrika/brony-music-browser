using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public class ReadOnlySongRepository
    : EfReadOnlyRepositoryBase<SongInfo, Song, BrowserContext>,
    IReadOnlySongRepository
{
    private readonly IFilterProcessorsProvider<Song, SongFilters>
        _filterProcessors;


    public ReadOnlySongRepository(
        BrowserContext context,
        IFilterProcessorsProvider<Song, SongFilters> filterProcessors)
        : base(context)
    {
        _filterProcessors = filterProcessors;
    }


    public async Task<List<SongInfo>> GetByFilters(SongFilters filters,
        int count, int offset)
    {
        var items = await ApplyFilters(_context.Songs, filters)
            .Include(e => e.Artists)
            .Include(e => e.Characters)
            .Include(e => e.Genres)
            .Skip(offset)
            .Take(count)
            .ToListAsync();

        return items.Select(x => Construct(x))
            .ToList();
    }


    public async Task<SongShortInfo> GetShort(int id)
    {
        var item = await _context.Songs
            .Include(e => e.Artists)
            .Select(e => new { Id = e.Id, Title = e.Title, Artists = e.Artists })
            .SingleAsync(e => e.Id == id);

        return new(
            item.Id,
            item.Title,
            item.Artists
                .Select(x => x.ArtistId)
                .ToList());
    }


    private IQueryable<Song> ApplyFilters(IQueryable<Song> query,
        SongFilters filters)
    {
        var processors = _filterProcessors.Get();
        var currentQuery = query;
        foreach (var processor in processors)
        {
            currentQuery = processor.ApplyFilter(currentQuery, filters);
        }
        return currentQuery;
    }
}

