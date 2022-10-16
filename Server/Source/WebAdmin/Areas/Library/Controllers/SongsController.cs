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
public class SongsController : Controller
{
    public readonly int PageStep = 10;

    private readonly ICrudRepository<Song, SongCreateArgs> _repository;
    private readonly IAuthorizationService _authorizationService;


    public SongsController(ICrudRepository<Song, SongCreateArgs> repository,
        IAuthorizationService authorizationService)
    {
        _repository = repository;
        _authorizationService = authorizationService;
    }


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
        return View(new LibraryIndexViewModel<Song>
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

        var song = await _repository.Get(id);
        if (!await Authorize(song, Operations.Update))
        {
            return Forbid();
        }

        var model = new SongCreateArgs(song.Title, song.Cover, song.Year, song.YouTubeId);

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int id, SongCreateArgs values)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }

        var song = await _repository.Get(id);
        if (!await Authorize(song, Operations.Update))
        {
            return Forbid();
        }

        song.UpdateDetails(
            values.Title,
            values.Year,
            values.YouTubeId,
            values.Cover);

        await _repository.SaveChanges();

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


    [HttpPost("Delete")]
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
    public async Task<IActionResult> CreateConfirmed(SongEditViewModel args)
    {
        if (!await Authorize(null, Operations.Create))
        {
            return Forbid();
        }
        var song = await _repository.Create(args.ToCreateArgs());

        return RedirectToAction("Edit", new { Id = song.Id });
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

