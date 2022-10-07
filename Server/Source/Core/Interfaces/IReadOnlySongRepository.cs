using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.Core.Interfaces;

public interface IReadOnlySongRepository : IReadOnlyRepository<SongInfo>
{
    Task<List<SongInfo>> GetByFilters(SongFilters filters,
        int count, int offset);

    Task<SongShortInfo> GetShort(int id);
}

