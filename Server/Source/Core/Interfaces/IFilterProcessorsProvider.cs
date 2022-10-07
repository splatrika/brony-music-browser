namespace Splatrika.BronyMusicBrowser.Core.Interfaces;

public interface IFilterProcessorsProvider<TEntity, TFilters>
{
    IEnumerable<IFilterProcessor<TEntity, TFilters>> Get(); 
}

