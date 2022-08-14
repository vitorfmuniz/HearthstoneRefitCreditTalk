using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace HearthstoneRefitCreditTalk.Extenstions;

public static class ConsoleLogExtentions
{
    public static void PrintJson<T>(this T @object)
        => Console.WriteLine(JsonConvert.SerializeObject(@object, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        }));

    public static void Print<T>(this T @object, string prefix = "")
        => Console.WriteLine($"{prefix}{@object?.ToString()}");
}
