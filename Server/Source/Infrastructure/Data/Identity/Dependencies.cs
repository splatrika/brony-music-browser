using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Splatrika.BronyMusicBrowser.Infrastructure.Data.Identity;

public static class Dependencies
{
    public static void AddIdentityContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration
            .GetConnectionString("IdentityConnection");

        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(connectionString));
    }
}

