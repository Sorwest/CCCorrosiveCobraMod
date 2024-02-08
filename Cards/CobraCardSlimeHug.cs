using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeHug : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeHug", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.rare,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeHug", "name"]).Localize
        });
    }
    public override string Name() => "Slime Hug";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = upgrade == Upgrade.A ? 0 : 1,
            exhaust = true,
            art = ModEntry.Instance.Sprites["EvolveBackgroundSprite"].Sprite,
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new()
        {
            new AStatus()
            {
                status = ModEntry.Instance.EvolveStatus.Status,
                statusAmount = upgrade == Upgrade.B ? 2 : 1,
                targetPlayer = true,
                dialogueSelector = ".SlimeHug"
            }
        };
        if (upgrade == Upgrade.A)
        {
            result.Add(new ADrawCard()
            {
                count = 1
            });
        };
        return result;
    }
}


