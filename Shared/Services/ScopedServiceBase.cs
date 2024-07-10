using System;
using System.Text;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Models;

namespace ToSic.Module.AnalyzeServiceLifetimes.Shared.Services;

public abstract class ScopedServiceBase
{
    /// <summary>
    /// A unique identifier for the service instance.
    /// This allows comparing the lifetime of different instances of the same service.
    /// </summary>
    public string Identifier { get; } = GetRandomKey();

    public string ServiceName => GetType().Name.Replace("Service", "");

    public ServiceLifetimeStatus GetStatus(string prefix = null) => new()
    {
        ServiceName = prefix + (string.IsNullOrEmpty(prefix) ? "" : " - ") + ServiceName,
        Identifier = Identifier
    };

    private static readonly char[] Characters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static readonly Random Random = new();

    private static string GetRandomKey()
    {
        var keyLength = Random.Next(8, 16); // Length of the key is between 8 and 16 characters
        var keyBuilder = new StringBuilder(keyLength);

        for (var i = 0; i < keyLength; i++)
            keyBuilder.Append(Characters[Random.Next(Characters.Length)]);

        return keyBuilder.ToString();
    }

}