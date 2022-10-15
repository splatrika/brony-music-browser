using Xunit;
using Moq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Splatrika.BronyMusicBrowser.Core.Constrants;
using Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Handlers;

namespace Splatrika.BronyMusicBrowser.Tests.Unit.WebAdmin.Authorization.Handlers;

public class AdminAuthorizationHandlerTests
{
    private AdminAuthorizationHandler _handler;
    private IAuthorizationRequirement _requirement;

    public AdminAuthorizationHandlerTests()
    {
        _handler = new();
        _requirement = new Mock<IAuthorizationRequirement>().Object;
    }

    [Fact]
    public async Task AuthorizeAdminToResource()
    {
        var user = new ClaimsPrincipal();
        var adminRole = new Claim(ClaimTypes.Role, Roles.Admin);
        user.AddIdentity(new(claims: new[] { adminRole }));

        var context = new AuthorizationHandlerContext(
            new[] { _requirement }, user, null);

        await _handler.HandleAsync(context);

        Assert.True(context.HasSucceeded);
    }


    [Fact]
    public async Task AuthorizeUserWithoutRolesToResource()
    {
        var user = new ClaimsPrincipal();

        var context = new AuthorizationHandlerContext(
            new[] { _requirement }, user, null);

        await _handler.HandleAsync(context);

        Assert.False(context.HasSucceeded);
    }
}

