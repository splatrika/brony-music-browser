using System;
namespace Splatrika.BronyMusicBrowser.Core.Interfaces;

public interface IReadOnlyRepository<T>
    where T : IReadOnlyProjection
{
    Task<T> Get(int id);

    Task<List<T>> GetAll(int count, int offset);

    Task<bool> Contains(int id);
}

