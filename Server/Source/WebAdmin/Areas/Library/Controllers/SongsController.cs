using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Requirements;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;

[Area("Library")]
[LibraryResourceController("Songs")]
public class SongsController : LibraryControllerBase
    <Song, SongCreateArgs, SongEditViewModel, SongEditViewModel>
{
    public SongsController(
        ICrudRepository<Song, SongCreateArgs> repository,
        IAuthorizationService authorizationService)
        : base(repository, authorizationService)
    {
    }

    public override Task<Song> Create(SongEditViewModel model,
        ICrudRepository<Song, SongCreateArgs> repository)
    {
        return repository.Create(new(
            model.Title,
            model.Cover,
            model.Year,
            model.YouTubeId));
    }


    public override void Edit(SongEditViewModel model, Song resource)
    {
        resource.UpdateDetails(
            model.Title,
            model.Year,
            model.YouTubeId,
            model.Cover);
    }


    public override SongEditViewModel GetEditViewModel(Song resource)
    {
        return new SongEditViewModel
        {
            Title = resource.Title,
            Cover = resource.Cover,
            Year = resource.Year,
            YouTubeId = resource.YouTubeId
        };
    }
}

