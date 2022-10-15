using Microsoft.AspNetCore.Authorization;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Authorization.Requirements;

public class LibraryOperationRequirement : IAuthorizationRequirement
{
    public string Operation { get; }


    public LibraryOperationRequirement(string operation)
    {
        Operation = operation;
    }
}

