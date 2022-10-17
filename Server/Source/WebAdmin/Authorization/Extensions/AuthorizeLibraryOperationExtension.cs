using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Requirements;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Extensions;

public static class AuthorizeLibraryOperationExtension
{
    public static async Task<bool> AuthorizeLibraryOperation(
        this IAuthorizationService _authorizationService,
        object? resource, string operation, ClaimsPrincipal user)
    {
        var result = await _authorizationService
            .AuthorizeAsync(
                user,
                resource,
                new LibraryOperationRequirement(operation));
        return result.Succeeded;
    }
}
