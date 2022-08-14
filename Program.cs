using HearthstoneRefitCreditTalk.DelegatingHandlers;
using HearthstoneRefitCreditTalk.Hearthstone.SearchParameters;

var hearthstoneApiBaseUrl = "https://omgvamp-hearthstone-v1.p.rapidapi.com";

var hearthstoneApiClient = RestService
    .For<IHearthStoneApi>(new HttpClient(new CancellationTokenPrinterDelegatingHandler()) { BaseAddress = new Uri(hearthstoneApiBaseUrl) });

var cts = new CancellationTokenSource();
cts.CancelAfter(5000);
var cards = await hearthstoneApiClient.GetCardsByRarity(
    CardRarity.Free,
    new CardSearchParams { Cost = 3 },
    cts.Token);