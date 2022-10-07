using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;

public class SongSearchStringProcessor : SongFilterProcessorBase
{
    public override IQueryable<Song> ApplyFilter(IQueryable<Song> query,
        SongFilters filters)
    {
        if (string.IsNullOrEmpty(filters.SearchString))
        {
            return query;
        }
        return query
            .Where(e => EF.Functions
                .FreeText(e.Title, filters.SearchString));
    }
}

