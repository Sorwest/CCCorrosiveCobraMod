using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardHeatHoarder : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("HeatHoarder", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.rare,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "HeatHoarder", "name"]).Localize
        });
    }
    public override string Name() => "Heat Hoarder";
    public override CardData GetData(State state)
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 1;
                num2 = 1;
                num3 = 2;
                break;
            case Upgrade.A:
                num = 0;
                num2 = 1;
                num3 = 2;
                break;
            case Upgrade.B:
                num = 3;
                num2 = 3;
                num3 = 3;
                break;
        }
        return new()
        {
            cost = num,
            singleUse = true,
            description = ModEntry.Instance.Localizations.Localize(["card", "HeatHoarder", "description"], new { Amount = num2, Count = num3 })
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num2 = 0;
        int num3 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num2 = 1;
                num3 = 2;
                break;
            case Upgrade.A:
                num2 = 1;
                num3 = 2;
                break;
            case Upgrade.B:
                num2 = 3;
                num3 = 3;
                break;
        }
        return new()
        {
            new AStatus()
            {
                status = ModEntry.Instance.HeatControlStatus.Status,
                statusAmount = num2,
                targetPlayer = true
            },
            new AAddCard()
            {
                card = new TrashMiasma()
                {
                    temporaryOverride = false,
                },
                amount = num3,
                destination = CardDestination.Deck
            }
        };
    }
}
