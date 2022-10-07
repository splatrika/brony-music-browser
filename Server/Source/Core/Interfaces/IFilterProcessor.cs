namespace Splatrika.BronyMusicBrowser.Core.Interfaces;

public interface IFilterProcessor<TEntity, TFilters>
{
    IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query,
        TFilters filters);
}

