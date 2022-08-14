#region Configuration
var builder = new ConfigurationBuilder();
var memoryCollection = new Dictionary<string, string>();
memoryCollection.Add("HearthStoneBaseAddress", "https://omgvamp-hearthstone-v1.p.rapidapi.com");
builder.AddInMemoryCollection(memoryCollection);
var configuration = builder.Build();
var serviceCollection = new ServiceCollection();
#endregion Configuration

#region Dependency Injection
serviceCollection.AddSingleton<IConfiguration>(configuration);
serviceCollection
    .AddRefitClient<IHearthStoneApi>(new RefitSettings
    {
        ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
        {
            Converters = { new StringEnumConverter() },
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
        })
    })
    .ConfigureHttpClient((s, c) =>
    {
        var config = s.GetService<IConfiguration>();
        var baseAddress = config.GetRequiredSection("HearthStoneBaseAddress").Value;
        c.BaseAddress = new Uri(baseAddress);
    });
#endregion Dependency Injection

var serviceProvider = serviceCollection.BuildServiceProvider();
var hearthstoneApiClient = serviceProvider.GetRequiredService<IHearthStoneApi>();

var cards = await hearthstoneApiClient.GetCardsByName("Animal Companion");
cards.PrintJson();