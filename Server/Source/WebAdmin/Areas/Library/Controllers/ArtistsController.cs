using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Requirements;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;

[Area("Library")]
[LibraryResourceController(resourceName: "Artists", order: 1)]
public class ArtistsController : LibraryControllerBase
    <Artist, ArtistCreateArgs, EditArtistViewModel, EditArtistViewModel>
{
    public ArtistsController(
        ICrudRepository<Artist,
        ArtistCreateArgs> repository,
        IAuthorizationService authorizationService)
        : base(repository, authorizationService)
    {
    }


    public override Task<Artist> Create(EditArtistViewModel model,
        ICrudRepository<Artist, ArtistCreateArgs> repository)
    {
        return repository.Create(new(model.Name));
    }


    public override void Edit(EditArtistViewModel model, Artist resource)
    {
        resource.UpdateDetails(model.Name);
    }


    public override EditArtistViewModel GetEditViewModel(Artist resource)
    {
        return new EditArtistViewModel
        {
            Name = resource.Name
        };
    }
}

