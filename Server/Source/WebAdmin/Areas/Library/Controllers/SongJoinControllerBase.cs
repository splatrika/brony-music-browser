using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;
using Splatrika.BronyMusicBrowser.WebAdmin.Attributes;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Extensions;
using Splatrika.BronyMusicBrowser.WebAdmin.ViewModels;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Areas.Library.Controllers;

[SongEditTabController(tabName: "Artists", order: 1)]
public abstract class SongJoinControllerBase<TJoin> : Controller
    where TJoin : IReadOnlyProjection
{
    public int PageStep { get; } = 10;

    private readonly ICrudRepository<Song, SongCreateArgs> _repository;
    private readonly IReadOnlyRepository<TJoin> _joinRepository;
    private readonly IAuthorizationService _authorizationService;


    public SongJoinControllerBase(
        ICrudRepository<Song, SongCreateArgs> reposiotory,
        IReadOnlyRepository<TJoin> joinRepository,
        IAuthorizationService authorizationService)
    {
        _repository = reposiotory;
        _joinRepository = joinRepository;
        _authorizationService = authorizationService;
    }


    public abstract IEnumerable<int> GetJoinsIds(Song song);
    public abstract void AddJoin(Song song, int joinId);
    public abstract bool CanAddJoin(Song song, int joinId, out string? reason);
    public abstract void RemoveJoin(Song song, int joinId);
    public abstract bool CanRemoveJoin(Song song, int joinId, out string? reason);


    public async Task<IActionResult> Index(int songId)
    {
        if (!await _repository.Contains(songId))
        {
            return NotFound();
        }
        var song = await _repository.Get(songId);
        if (!await _authorizationService
                .AuthorizeLibraryOperation(song, Operations.Read, User))
        {
            return Challenge();
        }
        var joinsIds = GetJoinsIds(song);
        var joins = new List<TJoin>();
        foreach (var id in joinsIds)
        {
            joins.Add(await _joinRepository.Get(id));
        }
        var model = new SongJoinIndexViewModel<TJoin>
        {
            Song = song,
            Items = joins
        };
        return View(model);
    }
    

    public async Task<IActionResult> Add(int songId, int? page,
        int? previousPage)
    {
        if (!await _repository.Contains(songId))
        {
            return NotFound();
        }
        var song = await _repository.Get(songId);
        var items = await _joinRepository
            .GetAll(PageStep, PageStep * page ?? 0);
        if (!await _authorizationService
                .AuthorizeLibraryOperation(items, Operations.Read, User))
        {
            return Challenge();
        }
        if (!items.Any())
        {
            return RedirectToAction("Add",
                new { songId = songId, page = previousPage ?? 0 });
        }
        return View(new AddSongJoinViewModel<TJoin>
        {
            Page = page ?? 0,
            PageStep = PageStep,
            Items = items,
            Song = song
        });
    }


    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> AddConfirmed(int songId, int id, int? page)
    {
        if (!await _repository.Contains(songId))
        {
            return NotFound();
        }
        var song = await _repository.Get(songId);
        if (!await _authorizationService
                .AuthorizeLibraryOperation(song, Operations.Update, User))
        {
            return Challenge();
        }
        if (!CanAddJoin(song, id, out string? reason))
        {
            ViewBag.ErrorMessage = reason;
            return await Add(songId, page ?? 0, 0);
        }
        AddJoin(song, id);
        await _repository.SaveChanges();
        return RedirectToAction("Index", new { songId = songId });
    }


    [HttpPost]
    public async Task<IActionResult> Remove(int songId, int id)
    {
        if (!await _repository.Contains(songId))
        {
            return NotFound();
        }
        var song = await _repository.Get(songId);
        if (!await _authorizationService
                .AuthorizeLibraryOperation(song, Operations.Update, User))
        {
            return Challenge();
        }
        if (!CanRemoveJoin(song, id, out string? reason)) {
            ViewBag.ErrorMessage = reason;
            return await Index(songId);
        }
        RemoveJoin(song, id);
        await _repository.SaveChanges();
        return RedirectToAction("Index", new { songId = songId });
    }
}
