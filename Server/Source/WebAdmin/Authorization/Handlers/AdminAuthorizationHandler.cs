using Microsoft.AspNetCore.Authorization;
using Splatrika.BronyMusicBrowser.Core.Constrants;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Handlers;

public class AdminAuthorizationHandler : IAuthorizationHandler
{
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        if (context.User.IsInRole(Roles.Admin))
        {
            foreach (var requirement in context.Requirements)
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}

