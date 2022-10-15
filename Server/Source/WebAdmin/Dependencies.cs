using Microsoft.AspNetCore.Authorization;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Handlers;

namespace Splatrika.BronyMusicBrowser.WebAdmin;

public static class Dependencies
{
    public static void AddAuthorisationHandlers(
        this IServiceCollection services)
    {
        services.AddSingleton<
            IAuthorizationHandler, AdminAuthorizationHandler>();
    }
}

