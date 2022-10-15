using System;
namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.ViewModels;

#nullable disable

public class IndexViewModel<TResource>
{
    public int Page { get; init; }
    public int PageStep { get; init; }
    public IEnumerable<TResource> Items { get; init; }
}

