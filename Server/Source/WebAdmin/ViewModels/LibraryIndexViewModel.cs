using System.Linq.Expressions;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class LibraryIndexViewModel<TResource>
{
    public int Page { get; init; }
    public int PageStep { get; init; }
    public IEnumerable<TResource> Items { get; init; }
}

