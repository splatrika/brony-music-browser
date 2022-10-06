using System;
namespace Splatrika.BronyMusicBrowser.Core.CreateArgs;

public class SongCreateArgs
{
    public string Title { get; set; }
    public string? Cover { get; set; }
    public int Year { get; set; }
    public string YouTubeId { get; set; }


    public SongCreateArgs(string title, string? cover, int year,
        string youTubeId)
    {
        Title = title;
        Cover = cover;
        Year = year;
        YouTubeId = youTubeId;
    }
}

