using Nanoray.PluginManager;
using Nickel;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true, rarity = Rarity.common)]
public class CobraCardShieldAlternatorB : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("ShieldAlternatorB", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B],
                dontOffer = true,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ShieldAlternatorB", "name"]).Localize
        });
    }
    public override string Name() => "Temp Shield Replica";
    public override CardData GetData(State state)
    {
        int num = 3;
        CardData result = new CardData()
        {
            cost = 1,
            exhaust = upgrade == Upgrade.B ? false : true,
            artTint = "e20fc2",
            description = ModEntry.Instance.Localizations.Localize(["card", "ShieldAlternatorB", "description", upgrade.ToString()], new { Amount = num })
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new AStatus()
            {
                status = Status.tempShield,
                statusAmount = 3,
                targetPlayer = true
            },
            new AAddCard()
            {
                card = new CobraCardShieldAlternatorA()
                {
                    upgrade = upgrade,
                    temporaryOverride = true
                },
                destination = CardDestination.Hand
            }
        };
    }
}
