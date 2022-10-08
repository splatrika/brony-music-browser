using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections.AlbumAggregate;

namespace Splatrika.BronyMusicBrowser.WebApi.Controllers;

public class AlbumsController : SimpleResourceControllerBase<AlbumInfo>
{
    private readonly IReadOnlyAlbumRepository _repository;


    public AlbumsController(IReadOnlyAlbumRepository repository)
        : base(repository)
    {
        _repository = repository;
    }


    [HttpGet("BySong/{songId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AlbumTitleInfo>> GetBySong(int songId)
    {
        var item = await _repository.GetFirstForSong(songId);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }


    [HttpGet("{id}/Title")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AlbumTitleInfo>> GetTitle(int id)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }
        var item = await _repository.GetTitle(id);
        return item;
    }
}

