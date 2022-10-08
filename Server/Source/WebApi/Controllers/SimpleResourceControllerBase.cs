using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class SimpleResourceControllerBase<T> : ControllerBase
    where T : IReadOnlyProjection
{
    private readonly IReadOnlyRepository<T> _repository;


    public SimpleResourceControllerBase(IReadOnlyRepository<T> repository)
    {
        _repository = repository;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<T>> Index(
        int count = 10, int offset = 0)
    {
        var items = await _repository.GetAll(count, offset);
        return items;
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<T>> Get(int id)
    {
        if (!await _repository.Contains(id))
        {
            return NotFound();
        }
        var item = await _repository.Get(id);
        return item;
    }
}

