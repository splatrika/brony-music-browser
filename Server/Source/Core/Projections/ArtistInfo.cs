using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Projections;

public class ArtistInfo : EntityBase, IReadOnlyProjection
{
    public string Name { get; private set; }

    public ArtistInfo(Artist original) : base(original.Id)
    {
        Name = original.Name;
    }
}

