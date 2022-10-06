using Ardalis.GuardClauses;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Core.Entities;

#nullable disable

public class Artist : EntityBase, IAggregationRoot
{
    public string Name { get; private set; }


    public Artist(int id, string name) : base(id)
    {
        UpdateDetails(name);
    }


    private Artist() { } //Required by EF Core


    public void UpdateDetails(string name)
    {
        Name = Guard.Against.NullOrEmpty(name);
    }
}

