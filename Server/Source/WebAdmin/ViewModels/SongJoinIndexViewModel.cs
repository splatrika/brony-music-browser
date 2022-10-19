using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class SongJoinIndexViewModel<TJoin>
{
    public Song Song { get; init; }
    public IEnumerable<TJoin> Items { get; init; }
}

