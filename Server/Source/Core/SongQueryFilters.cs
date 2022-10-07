using System;
namespace Splatrika.BronyMusicBrowser.Core;

public class SongFilters
{
    public string? SearchString { get; set; }
    public List<int>? Genres { get; set; }
    public List<int>? Characters { get; set; }
}

