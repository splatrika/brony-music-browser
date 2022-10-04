using Ardalis.GuardClauses;

namespace Splatrika.BronyMusicBrowser.Core.Entities;

#nullable disable

public class Genre : EntityBase
{
    public string Caption { get; private set; }
    public int Order { get; private set; }


    public Genre(int id, string caption, int order) : base(id)
    {
        UpdateDetails(caption, order);
    }


    private Genre() { } //Required by EF Core


    public void UpdateDetails(string caption, int order)
    {
        Caption = Guard.Against.NullOrEmpty(caption);
        Order = order;
    }
}

