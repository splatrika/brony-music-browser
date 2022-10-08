using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;

namespace Splatrika.BronyMusicBrowser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SongsController : SimpleResourceControllerBase<SongInfo>
{
    private readonly IReadOnlySongRepository _repository;


    public SongsController(IReadOnlySongRepository repository)
        : base(repository)
    {
        _repository = repository;
    }


    [HttpGet("Search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<SongInfo>> Search(
        [FromQuery] SongFilters filters, int count = 10, int offset = 0)
    {
        var items = await _repository.GetByFilters(filters, count, offset);
        return items;
    }


    [HttpGet("{id}/Short")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SongShortInfo>> GetShort(int id)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }
        var item = await _repository.GetShort(id);
        return Ok(item);
    }
}

