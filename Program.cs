#region Configuration
var builder = new ConfigurationBuilder();
var memoryCollection = new Dictionary<string, string>();
memoryCollection.Add("X-RapidAPI-Key", "<PutYourApiKeyHere>");
memoryCollection.Add("HearthStoneBaseAddress", "https://omgvamp-hearthstone-v1.p.rapidapi.com");
builder.AddInMemoryCollection(memoryCollection);
var configuration = builder.Build();
var serviceCollection = new ServiceCollection();
#endregion Configuration

#region Dependency Injection
serviceCollection.AddScoped<HearthstoneApiKeyInjectorDelegatingHandler>();
serviceCollection.AddSingleton<IConfiguration>(configuration);
var httpClientBuilder = serviceCollection
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

#region Microsoft.Extensions.Http.Polly
var retryPolicy = HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(3, retryAttempt =>
        {
            retryAttempt.Print("Attempt: ");
            return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
        });
httpClientBuilder.AddHttpMessageHandler<HearthstoneApiKeyInjectorDelegatingHandler>();
httpClientBuilder.AddPolicyHandler(retryPolicy);
#endregion Microsoft.Extensions.Http.Polly

var serviceProvider = serviceCollection.BuildServiceProvider();
var hearthstoneApiClient = serviceProvider.GetRequiredService<IHearthStoneApi>();

try
{
    var cards = await hearthstoneApiClient.GetCardsByName("xpto");
    cards.PrintJson();
}
catch (ApiException e)
{
    (await e.GetContentAsAsync<HearthstoneError>()).Print("GetContentAsAsync: ");
}