using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardShieldAlternatorA : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("ShieldAlternatorA", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ShieldAlternatorA", "name"]).Localize
        });
    }
    public override string Name() => "Shield Replica";
    public override CardData GetData(State state)
    {
        int num = 2;
        CardData result = new CardData()
        {
            cost = upgrade == Upgrade.A ? 0 : 1,
            exhaust = true,
            artTint = "005555",
            description = ModEntry.Instance.Localizations.Localize(["card", "ShieldAlternatorA", "description", upgrade.ToString()], new { Amount = num })
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new AStatus()
            {
                status = Status.shield,
                statusAmount = 2,
                targetPlayer = true,
            },
            new AAddCard()
            {
                card = new CobraCardShieldAlternatorB()
                {
                    upgrade = upgrade,
                    temporaryOverride = true,
                },
                destination = CardDestination.Deck
            },
        };
    }
}
