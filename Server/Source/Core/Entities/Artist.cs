using Ardalis.GuardClauses;

namespace Splatrika.BronyMusicBrowser.Core.Entities;

#nullable disable

public class Artist : EntityBase
{
    public string Name { get; private set; }


    public Artist(int id, string name) : base(id)
    {
        UpdateDetails(name);
    }


    private void UpdateDetails(string name)
    {
        Name = Guard.Against.NullOrEmpty(name);
    }
}

