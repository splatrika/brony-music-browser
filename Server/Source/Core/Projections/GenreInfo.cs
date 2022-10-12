using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Projections;

public class GenreInfo : EntityBase, IReadOnlyProjection
{
    public string Caption { get; set; }
    public int Order { get; set; }

    public GenreInfo(Genre original) : base(original.Id)
    {
        Caption = original.Caption;
        Order = original.Order;
    }
}

