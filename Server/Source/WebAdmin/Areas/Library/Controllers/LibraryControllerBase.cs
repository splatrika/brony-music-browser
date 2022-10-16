using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Requirements;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;


public abstract class LibraryControllerBase
    <TResource, TCreateArgs, TCreateViewModel, TEditViewModel>
    : Controller
    where TResource: EntityBase, IAggregationRoot
{
    public int PageStep { get; } = 10;

    private readonly ICrudRepository<TResource, TCreateArgs> _repository;
    private readonly IAuthorizationService _authorizationService;


    public LibraryControllerBase(
        ICrudRepository<TResource, TCreateArgs> repository,
        IAuthorizationService authorizationService)
    {
        _repository = repository;
        _authorizationService = authorizationService;
    }


    [NonAction]
    public abstract Task<TResource> Create(TCreateViewModel model,
        ICrudRepository<TResource, TCreateArgs> repository);

    [NonAction]
    public abstract void Edit(TEditViewModel model, TResource resource);

    [NonAction]
    public abstract TEditViewModel GetEditViewModel(TResource resource);


    public async Task<IActionResult> Index(int? page, int? previousPage)
    {
        var songs = await _repository.GetAll(
            count: PageStep,
            offset: PageStep * page ?? 0);
        if (!await Authorize(songs, Operations.Read))
        {
            return Forbid();
        }
        if (songs.Count() == 0)
        {
            return RedirectToAction("Index",
                new { page = previousPage ?? 0 });
        }
        return View(new LibraryIndexViewModel<TResource>
        {
            PageStep = PageStep,
            Page = page ?? 0,
            Items = songs
        });
    }


    public async Task<IActionResult> Edit(int id)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }

        var item = await _repository.Get(id);
        if (!await Authorize(item, Operations.Update))
        {
            return Forbid();
        }

        var model = GetEditViewModel(item);

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int id, TEditViewModel values)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }

        var item = await _repository.Get(id);
        if (!await Authorize(item, Operations.Update))
        {
            return Forbid();
        }

        Edit(values, item);

        await _repository.SaveChanges();

        if (!ModelState.IsValid)
        {
            return View(values);
        }

        return RedirectToAction("Edit", new { Id = id });
    }


    public async Task<IActionResult> Delete(int id)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }
        if (!await Authorize(null, Operations.Delete))
        {
            return Forbid();
        }

        var song = await _repository.Get(id);
        return View(song);
    }


    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }
        if (!await Authorize(null, Operations.Delete))
        {
            return Forbid();
        }

        await _repository.Delete(id);
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Create()
    {
        if (!await Authorize(null, Operations.Create))
        {
            return Forbid();
        }

        return View();
    }


    [HttpPost]
    [ActionName("Create")]
    public async Task<IActionResult> CreateConfirmed(TCreateViewModel values)
    {
        if (!await Authorize(null, Operations.Create))
        {
            return Forbid();
        }
        var item = await Create(values, _repository);

        if (!ModelState.IsValid)
        {
            return View(values);
        }

        return RedirectToAction("Edit", new { Id = item.Id });
    }


    private async Task<bool> Authorize(object? resource, string operation)
    {
        var result = await _authorizationService
            .AuthorizeAsync(
                User,
                resource,
                new LibraryOperationRequirement(operation));
        return result.Succeeded;
    }
}

