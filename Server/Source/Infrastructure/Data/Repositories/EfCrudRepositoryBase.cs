using System;
using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;

public abstract class EfCrudRepositoryBase<TEntity, TCreateArgs, TContext>
    : ICrudRepository<TEntity, TCreateArgs>
    where TEntity : EntityBase, IAggregationRoot
    where TContext : DbContext
{
    private readonly TContext _context;


    public EfCrudRepositoryBase(TContext context)
    {
        _context = context;
    }


    public async Task<TEntity> Create(TCreateArgs args)
    {
        var entity = Construct(args);
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    public async Task<bool> Contains(int id)
    {
        return await _context.Set<TEntity>().AnyAsync(e => e.Id == id);
    }


    public async Task<bool> Any()
    {
        return await _context.Set<TEntity>().AnyAsync();
    }


    public async Task Delete(int id)
    {
        await CheckContains(id);
        var entity = await _context.Set<TEntity>().FindAsync(id);
        _context.Remove(entity!);
        await _context.SaveChangesAsync();
    }
        

    public async Task<TEntity> Get(int id)
    {
        await CheckContains(id);
        var item = await _context.Set<TEntity>()
            .SingleAsync(e => e.Id == id);

        var entry = _context.Entry(item);
        foreach (var navigation in entry.Navigations)
        {
            await navigation.LoadAsync();
        }

        return item;
    }


    public async Task<List<TEntity>> GetAll(int id, int count, int offset)
    {
        var items = await _context.Set<TEntity>()
            .AsNoTracking()
            .Skip(offset)
            .Take(count)
            .ToListAsync();

        foreach (var item in items)
        {
            var entry = _context.Entry(item);
            foreach (var navigation in entry.Navigations)
            {
                await navigation.LoadAsync();
            }
        }

        return items;
    }


    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }


    protected abstract TEntity Construct(TCreateArgs args);


    private async Task CheckContains(int id)
    {
        if (!await Contains(id))
        {
            throw new InvalidOperationException(
                $"There is no item with id {id}");
        }
    }
}

