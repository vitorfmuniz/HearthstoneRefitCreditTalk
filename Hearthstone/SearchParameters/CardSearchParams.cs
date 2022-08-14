namespace HearthstoneRefitCreditTalk.Hearthstone.SearchParameters;

public class CardSearchParams
{
    [AliasAs("cost")]
    public int? Cost { get; set; }
    [AliasAs("attack")]
    public int? Attack { get; set; }
    [AliasAs("durability ")]
    public int? Durability { get; set; }
    [AliasAs("health")]
    public int? Health { get; set; }
}