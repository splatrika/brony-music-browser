using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;

public class SongGenresProcessor : SongFilterProcessorBase
{
    public override IQueryable<Song> ApplyFilter(IQueryable<Song> query,
        SongFilters filters)
    {
        if (filters.Genres == null)
        {
            return query;
        }
        return query
            .Where(e => e.Genres.Any(x =>
                filters.Genres.Any(y => y == x.GenreId)));
    }
}

