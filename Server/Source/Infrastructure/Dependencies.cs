using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;
using Splatrika.BronyMusicBrowser.Core.Interfaces;
using Splatrika.BronyMusicBrowser.Core.Projections;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories.ReadOnly;
using Splatrika.BronyMusicBrowser.Core.CreateArgs;
using Splatrika.BronyMusicBrowser.Core.Entities.AlbumAggregate;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Repositories;
using Splatrika.BronyMusicBrowser.Core.Entities;
using Splatrika.BronyMusicBrowser.Core;
using Splatrika.BronyMusicBrowser.Infrastructure.Data.Filters;

namespace Splatrika.BronyMusicBrowser.Infrastructure;

public static class Dependencies
{
    public static void AddBrowserContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("BrowserConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new NullReferenceException(
                "Set ConnectionStrings:BrowserConnection in configuration");
        }
        services.AddDbContext<BrowserContext>(options =>
            options.UseSqlServer(connectionString));
    }


    public static void AddCrudRepositories(this IServiceCollection services)
    {
        services.AddScoped<
            ICrudRepository<Artist, ArtistCreateArgs>, ArtistCrudRepository>();
        services.AddScoped<
            ICrudRepository<Character, CharacterCreateArgs>,
            CharacterCrudRepository>();
        services.AddScoped<
            ICrudRepository<Genre, GenreCreateArgs>, GenreCrudRepository>();
        services.AddScoped<
            ICrudRepository<Song, SongCreateArgs>, SongCrudRepository>();
        services.AddScoped<
            ICrudRepository<Album, AlbumCreateArgs>, AlbumCrudRepository>();
    }
}

