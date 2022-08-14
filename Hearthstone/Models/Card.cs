using System.Text.Json.Serialization;

namespace HearthstoneRefitCreditTalk.Hearthstone.Models;

public sealed class Card
{
    [JsonPropertyName("cardId")]
    public string Id { get; set; } = "Unknown";
    public string Name { get; set; } = "Unknown";
    public string CardSet { get; set; } = "Unknown";
    public CardType Type { get; set; } = CardType.None;
    public CardRarity Rarity { get; set; } = CardRarity.None;
    public CardFaction Faction { get; set; } = CardFaction.None;
    [JsonPropertyName("playerClass")]
    public string Hero { get; set; } = "Unknown";
    public string Text { get; set; } = "Unknown";
    public string Flavor { get; set; } = "Unknown";
    public int Cost { get; set; }
    public int Attack { get; set; }
    public int Health { get; set; }
    public Mechanic[]? Mechanics { get; set; }
}
