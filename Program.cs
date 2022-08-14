using HearthstoneRefitCreditTalk.Hearthstone.SearchParameters;

var hearthstoneApiBaseUrl = "https://omgvamp-hearthstone-v1.p.rapidapi.com";

var hearthstoneApiClient = RestService
    .For<IHearthStoneApi>(hearthstoneApiBaseUrl);

var cards = await hearthstoneApiClient.GetCardsByRarity(CardRarity.Free, new CardSearchParams { Cost = 3 });

cards
    .PrintJson();