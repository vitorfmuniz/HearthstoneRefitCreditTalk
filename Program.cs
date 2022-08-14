var hearthstoneApiBaseUrl = "https://omgvamp-hearthstone-v1.p.rapidapi.com";

var hearthstoneApiClient = RestService
    .For<IHearthStoneApi>(hearthstoneApiBaseUrl);

var cards = await hearthstoneApiClient.GetCardsByRarity(CardRarity.Free);

cards
    .PrintJson();