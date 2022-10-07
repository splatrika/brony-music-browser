using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Projections.AlbumAggregate;

public class AlbumInfo : EntityBase, IReadOnlyProjection
{
    public string Title { get; private set; }
    public string Cover { get; private set; }
    public IReadOnlyCollection<int> Songs { get; private set; }
    public IReadOnlyCollection<int> Artists { get; private set; }

    public AlbumInfo(Album original) : base(original.Id)
    {
        Title = original.Title;
        Cover = original.Cover;

        Songs = original.Songs
            .Select(x => x.SongId)
            .ToList()
            .AsReadOnly();

        Artists = original.Artists
            .Select(x => x.ArtistId)
            .ToList()
            .AsReadOnly();
    }
}
