namespace HearthstoneRefitCreditTalk.Hearthstone;

[Headers(
    "X-RapidAPI-Key: <PutYourApiKeyHere>",
    "X-RapidAPI-Host: omgvamp-hearthstone-v1.p.rapidapi.com"
    )]
public interface IHearthStoneApi
{
    [Get("/cards/qualities/{quality}?collectible=1")]
    public Task<IEnumerable<Card>> GetCardsByRarity([AliasAs("quality")] CardRarity rarity, [Query] CardSearchParams? @params = null);
}
