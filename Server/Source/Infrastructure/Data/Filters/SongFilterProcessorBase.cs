using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;


public abstract class SongFilterProcessorBase
    : IFilterProcessor<Song, SongFilters>
{
    public abstract IQueryable<Song> ApplyFilter(IQueryable<Song> query,
        SongFilters filters);
}

