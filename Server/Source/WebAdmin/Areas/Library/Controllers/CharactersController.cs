using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;

[Area("Library")]
[LibraryResourceController(resourceName: "Characters", order: 2)]
public class CharactersController : LibraryControllerBase
    <Character, CharacterCreateArgs,
    EditCharacterViewModel, EditCharacterViewModel>
{
    public CharactersController(
        ICrudRepository<Character, CharacterCreateArgs> repository,
        IAuthorizationService authorizationService)
        : base(repository, authorizationService)
    {
    }


    public override Task<Character> Create(
        EditCharacterViewModel model,
        ICrudRepository<Character, CharacterCreateArgs> repository)
    {
        return repository.Create(new(model.Name, model.Icon, model.Order));
    }


    public override void Edit(EditCharacterViewModel model, Character resource)
    {
        resource.UpdateDetails(model.Name, model.Icon, model.Order);
    }


    public override EditCharacterViewModel GetEditViewModel(Character resource)
    {
        return new EditCharacterViewModel
        {
            Name = resource.Name,
            Icon = resource.Icon,
            Order = resource.Order
        };
    }
}

