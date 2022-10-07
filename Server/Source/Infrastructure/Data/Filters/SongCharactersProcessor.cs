using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;

public class SongCharactersProcessor : SongFilterProcessorBase
{
    public override IQueryable<Song> ApplyFilter(IQueryable<Song> query,
        SongFilters filters)
    {
        if (filters.Characters == null)
        {
            return query;
        }
        return query
            .Where(e => e.Characters.Any(x =>
                filters.Characters.Any(y => y == x.CharacterId)));
    }
}

