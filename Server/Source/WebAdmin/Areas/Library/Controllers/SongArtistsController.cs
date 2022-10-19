using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;

[Area("Library")]
public class SongArtistsController : SongJoinControllerBase<ArtistInfo>
{
    public SongArtistsController(
        ICrudRepository<Song, SongCreateArgs> reposiotory,
        IReadOnlyRepository<ArtistInfo> joinRepository,
        IAuthorizationService authorizationService)
        : base(reposiotory, joinRepository, authorizationService)
    {
    }

    public override void AddJoin(Song song, int joinId)
    {
        song.AddArtist(joinId);
    }


    public override bool CanAddJoin(Song song, int joinId, out string? reason)
    {
        if (song.Artists.Any(x => x.ArtistId == joinId))
        {
            reason = "This artist is already assigned to this song";
            return false;
        }
        reason = null;
        return true;
    }


    public override bool CanRemoveJoin(Song song, int joinId,
        out string? reason)
    {
        if (!song.Artists.Any(x => x.ArtistId == joinId))
        {
            reason = "This artist isn't assigned to this song";
            return false;
        }
        reason = null;
        return true;
    }


    public override IEnumerable<int> GetJoinsIds(Song song)
    {
        return song.Artists.Select(x => x.ArtistId);
    }


    public override void RemoveJoin(Song song, int joinId)
    {
        song.RemoveArtist(joinId);
    }
}

