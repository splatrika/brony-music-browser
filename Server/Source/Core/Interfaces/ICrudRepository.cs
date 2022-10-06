using System;
namespace Splatrika.BronyMusicBrowser.Core.Interfaces;

public interface ICrudRepository<TEntity, TCreateArgs>
    where TEntity : IAggregationRoot
{
    Task<TEntity> Create(TCreateArgs args);

    Task<TEntity> Get(int id);

    Task SaveChanges();

    Task Delete(int id);

    Task<bool> Contains(int id);

    Task<List<TEntity>> GetAll(int id, int count, int offset);
}

