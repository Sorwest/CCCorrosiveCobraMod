using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeHeal : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeHeal", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B],
                dontOffer = true,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeHeal", "name"]).Localize
        });
    }
    public override string Name() => "Slime Heal";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = upgrade == Upgrade.A ? 2 : 1,
            exhaust = true,
            art = ModEntry.Instance.Sprites["RepairsSprite"].Sprite
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = upgrade == Upgrade.A ? 2 : 1;
        int num2 = upgrade == Upgrade.B ? 4 : 1;
        return new()
        {
            new AHeal()
            {
                healAmount = num,
                targetPlayer = true,
                canRunAfterKill = true
            },
            new ADrawCard()
            {
                count = num2
            }
        };
    }
}
