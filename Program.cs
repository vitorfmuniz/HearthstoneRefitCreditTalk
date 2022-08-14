var hearthstoneApiBaseUrl = "https://omgvamp-hearthstone-v1.p.rapidapi.com";

var hearthstoneApiClient = RestService
    .For<IHearthStoneApi>(hearthstoneApiBaseUrl,
#region Setttings
    new RefitSettings
    {
        ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
        {
            Converters = { new StringEnumConverter() },
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
        })
    });
#endregion Setttings

var cards = await hearthstoneApiClient.GetCardsByName("Animal Companion");
cards.PrintJson();