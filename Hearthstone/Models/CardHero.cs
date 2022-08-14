using System.Runtime.Serialization;

namespace HearthstoneRefitCreditTalk.Hearthstone.Models;

public enum CardHero
{
    [EnumMember(Value = "Demon Hunter")]
    DemonHunter,
    Paladin,
    Rogue,
    Shaman,
    Priest,
    Warrior,
    Mage,
    Druid,
    Hunter,
    Warlock,
    Neutral
}