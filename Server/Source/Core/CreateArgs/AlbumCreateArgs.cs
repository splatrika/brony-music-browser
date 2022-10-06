using System;
namespace Splatrika.BronyMusicBrowser.Core.CreateArgs;

public class AlbumCreateArgs
{
    public string Title { get; set; }
    public string? Cover { get; set; }
    public int FirstSongId { get; set; }


    public AlbumCreateArgs(string title, string? cover, int firstSongId)
    {
        Title = title;
        Cover = cover;
        FirstSongId = firstSongId;
    }
}

