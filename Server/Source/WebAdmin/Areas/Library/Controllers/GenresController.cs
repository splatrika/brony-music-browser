using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;

[Area("Library")]
[LibraryResourceController(resourceName: "Genres", order: 3)]
public class GenresController : LibraryControllerBase
    <Genre, GenreCreateArgs, EditGenreViewModel, EditGenreViewModel>
{
    public GenresController(
        ICrudRepository<Genre, GenreCreateArgs> repository,
        IAuthorizationService authorizationService)
        : base(repository, authorizationService)
    {
    }


    public override Task<Genre> Create(EditGenreViewModel model,
        ICrudRepository<Genre, GenreCreateArgs> repository)
    {
        return repository.Create(new(model.Caption, model.Order));
    }


    public override void Edit(EditGenreViewModel model, Genre resource)
    {
        resource.UpdateDetails(model.Caption, model.Order);
    }


    public override EditGenreViewModel GetEditViewModel(Genre resource)
    {
        return new EditGenreViewModel
        {
            Caption = resource.Caption,
            Order = resource.Order
        };
    }
}

