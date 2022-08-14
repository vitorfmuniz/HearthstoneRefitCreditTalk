using System.Text.Json;
using System.Text.Json.Serialization;

namespace HearthstoneRefitCreditTalk.Extenstions;

public static class ConsoleLogExtentions
{
    public static void PrintJson<T>(this T @object)
        => Console.WriteLine(JsonSerializer.Serialize(@object, new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        }
        ));

    public static void Print<T>(this T @object,string prefix = "")
        => Console.WriteLine($"{prefix}{@object?.ToString()}");
}
