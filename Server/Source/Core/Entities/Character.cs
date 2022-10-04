using Ardalis.GuardClauses;

namespace Splatrika.BronyMusicBrowser.Core.Entities;

#nullable disable

public class Character : EntityBase
{
    public string Name { get; private set; }
    public string Icon { get; private set; }
    public int Order { get; private set; }

    public Character(int id, string name, string icon, int order) : base(id)
    {
        UpdateDetails(name, icon, order);
    }

    public void UpdateDetails(string name, string icon, int order)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Icon = icon;
        Order = order;
    }
}

