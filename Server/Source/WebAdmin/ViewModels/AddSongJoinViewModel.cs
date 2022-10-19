using Splatrika.BronyMusicBrowser.Core.Entities;

namespace Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

#nullable disable

public class AddSongJoinViewModel<TJoin> : LibraryIndexViewModel<TJoin>
{
    public Song Song { get; init; }
}

