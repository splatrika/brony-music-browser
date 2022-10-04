using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Splatrika.BronyMusicBrowser.Infrastructure.Data;

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
}

