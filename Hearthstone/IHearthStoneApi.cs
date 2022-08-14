namespace HearthstoneRefitCreditTalk.Hearthstone;

[Headers(
    "X-RapidAPI-Key: <PutYourApiKeyHere>",
    "X-RapidAPI-Host: omgvamp-hearthstone-v1.p.rapidapi.com"
    )]
public interface IHearthStoneApi
{
    [Get("/cards/qualities/{quality}?collectible=1")]
    public Task<IEnumerable<Card>> GetCardsByRarity(
        [AliasAs("quality")] CardRarity rarity,
        [Query] CardSearchParams? @params = null,
        CancellationToken cancellationToken = default);

    [Get("/cards/search/{name}")]
    public Task<IEnumerable<Card>> GetCardsByName(string name);

    #region Not throwing
    //[Get("/cards/search/{name}")]
    //public Task<ApiResponse<IEnumerable<Card>>> GetCardsByName(string name);
    #endregion  Not throwing
}
