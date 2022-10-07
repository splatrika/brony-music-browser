using Newtonsoft.Json;
using Xunit;

namespace Splatrika.BronyMusicBrowser.Tests.Unit.Extensions;

public static class AssertExtensions
{
    public static void SequenceEqual<T>(
        IEnumerable<T> excepted,
        IEnumerable<T> actual)
    {
        var exceptedView = JsonConvert.SerializeObject(excepted);
        var actualView = JsonConvert.SerializeObject(actual);
        var message = $"Excepted: {exceptedView}\nActual: {actualView}";
        Assert.True(excepted.SequenceEqual(actual), message);
    }
}

