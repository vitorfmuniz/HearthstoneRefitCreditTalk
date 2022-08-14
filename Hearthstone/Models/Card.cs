namespace HearthstoneRefitCreditTalk.Hearthstone.Models;

public sealed class Card
{
    [JsonProperty("cardId")]
    public string Id { get; set; } = "Unknown";
    public string Name { get; set; } = "Unknown";
    public string CardSet { get; set; } = "Unknown";
    public CardType Type { get; set; } = CardType.None;
    public CardRarity Rarity { get; set; } = CardRarity.None;
    public CardFaction Faction { get; set; } = CardFaction.None;
    [JsonProperty("playerClass")]
    public CardHero Hero { get; set; } = CardHero.Neutral;
    public string Text { get; set; } = "Unknown";
    public string Flavor { get; set; } = "Unknown";
    public int Cost { get; set; }
    public int Attack { get; set; }
    public int Health { get; set; }
    public Mechanic[]? Mechanics { get; set; }
}
