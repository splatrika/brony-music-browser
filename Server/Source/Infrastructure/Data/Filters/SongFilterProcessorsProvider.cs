using Microsoft.Extensions.DependencyInjection;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;

public class SongFilterProcessorsProvider
    : IFilterProcessorsProvider<Song, SongFilters>
{
    private List<IFilterProcessor<Song, SongFilters>> _filters;


    public SongFilterProcessorsProvider(IServiceProvider provider)
    {
        var assembly = typeof(SongFilterProcessorsProvider).Assembly;

        var filterTypes = assembly.GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                x.IsSubclassOf(typeof(SongFilterProcessorBase)));

        _filters = filterTypes
            .Select(x => (ActivatorUtilities.CreateInstance(provider, x)
                as IFilterProcessor<Song, SongFilters>)!)
            .ToList();
    }


    public IEnumerable<IFilterProcessor<Song, SongFilters>> Get()
    {
        return _filters;
    }
}

