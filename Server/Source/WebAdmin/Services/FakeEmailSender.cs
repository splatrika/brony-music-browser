using System;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Splatrika.BronyMusicBrowser.WebAdmin.Services;

public class FakeEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine(
            $"Fake email sender to {email} ({subject}): {htmlMessage}");
        return Task.CompletedTask;
    }
}

