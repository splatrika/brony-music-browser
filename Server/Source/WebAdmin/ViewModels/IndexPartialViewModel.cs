using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class IndexPartialViewModel
{
    public int Page { get; init; }
    public int PageStep { get; init; }
    public IEnumerable<EntityBase> Items { get; init; }
    public IEnumerable<ColumnInfo> Columns { get; init; }
    public string ActionsPartialName { get; init; }

    public class ColumnInfo
    {
        public string Name { get; init; }
        public Func<dynamic, dynamic> Getter { get; init; }
    }
}
