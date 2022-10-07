using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core.Interfaces;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;

public abstract class EfReadOnlyRepositoryBase<TProjection, TEntity, TContext>
    : IReadOnlyRepository<TProjection>
    where TProjection : class, IReadOnlyProjection
    where TEntity : EntityBase
    where TContext : DbContext
{
    protected readonly TContext _context;


    public EfReadOnlyRepositoryBase(TContext context)
    {
        _context = context;
    }


    public async Task<bool> Contains(int id)
    {
        return await _context.Set<TEntity>()
            .AnyAsync(e => e.Id == id);
    }


    public async Task<TProjection> Get(int id)
    {
        await CheckContains(id);

        var original = await _context.Set<TEntity>()
            .SingleOrDefaultAsync(e => e.Id == id);

        LoadNavigations(original!);

        return Construct(original!);
    }


    public async Task<List<TProjection>> GetAll(int count, int offset)
    {
        var originals = await _context.Set<TEntity>()
            .Skip(offset)
            .Take(count)
            .ToListAsync();

        foreach (var original in originals)
        {
            LoadNavigations(original);
        }

        return originals.Select(e => Construct(e))
            .ToList();
    }


    protected async Task CheckContains(int id)
    {
        if (!await Contains(id))
        {
            throw new ArgumentException($"There is no item with id {id}");
        }
    }


    protected TProjection Construct(TEntity original)
    {
        return (TProjection)Activator
            .CreateInstance(typeof(TProjection), original)!;
    }


    protected void LoadNavigations(TEntity entity)
    {
        foreach (var navigation in _context.Entry(entity).Navigations)
        {
            navigation.Load();
        }
    }
}

