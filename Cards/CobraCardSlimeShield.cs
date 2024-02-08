using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeShield : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeShield", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.uncommon,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeShield", "name"]).Localize
        });
    }
    public override string Name() => "Slime Shield";
    public override CardData GetData(State state)
    {
        int num = upgrade == Upgrade.B ? 1 : 2;
        return new()
        {
            cost = 1,
            exhaust = true,
            artTint = "005555",
            description = ModEntry.Instance.Localizations.Localize(["card", "SlimeShield", "description", upgrade.ToString()], new { Amount = num })
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = upgrade == Upgrade.B ? 1 : 2;
        return new()
        {
            new AStatus()
            {
                status = Status.shield,
                statusAmount = num,
                targetPlayer = true
            },
            new AAddCard()
            {
                card = new CobraCardSlimeHeal()
                {
                    upgrade = upgrade,
                    temporaryOverride = true
                }
            }
        };
    }
}
