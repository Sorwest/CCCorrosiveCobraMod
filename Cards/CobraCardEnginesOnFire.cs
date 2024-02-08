using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;
public class CobraCardEnginesOnFire : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("EnginesOnFine", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.rare,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "EnginesOnFine", "name"]).Localize
        });
    }
    public override string Name() => "Engines! On Fire!";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = upgrade == Upgrade.B ? 1 : 0,
            buoyant = upgrade == Upgrade.B ? true : false,
            exhaust = true,
            art = ModEntry.Instance.Sprites["HeatSprite"].Sprite
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 2;
                break;
            case Upgrade.A:
                num = 3;
                break;
            case Upgrade.B:
                num = 1;
                break;
        };
        List<CardAction> result = new()
        {
            new AStatus()
            {
                status = ModEntry.Instance.HeatOutbreakStatus.Status,
                statusAmount = num,
                targetPlayer = false
            }
        };
        if (upgrade != Upgrade.B)
        {
            result.Add(new AStatus()
            {
                status = ModEntry.Instance.HeatOutbreakStatus.Status,
                statusAmount = 1,
                targetPlayer = true
            });
        }
        return result;
    }
}
