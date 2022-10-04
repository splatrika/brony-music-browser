﻿namespace Splatrika.BronyMusicBrowser.Core.Entities.ReadOnly;


public class SongInfo : EntityBase
{
    public string Title { get; private set; }
    public string Cover { get; private set; }
    public int Year { get; private set; }
    public string YouTubeId { get; private set; }


    public SongInfo(Song original) : base(original.Id)
    {
        Title = original.Title;
        Cover = original.Cover;
        Year = original.Year;
        YouTubeId = original.YouTubeId;
    }
}

