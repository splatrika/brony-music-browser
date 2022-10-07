using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Projections;

public class CharacterInfo : EntityBase, IReadOnlyProjection
{
    public string Name { get; private set; }
    public string Icon { get; private set; }
    public int Order { get; private set; }


    public CharacterInfo(Character original) : base(original.Id)
    {
        Name = original.Name;
        Icon = original.Icon;
        Order = original.Order;
    }
}

