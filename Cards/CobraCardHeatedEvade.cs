using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardHeatedEvade : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("HeatedEvade", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "HeatedEvade", "name"]).Localize
        });
    }
    public override string Name() => "Heated Evade";
    public override CardData GetData(State state)
    {
        return new CardData
        {
            cost = upgrade == Upgrade.A ? 0 : 1,
            art = ModEntry.Instance.Sprites["BoxHeatSprite"].Sprite,
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new();
        switch (upgrade)
        {

            case Upgrade.None:
                result = new()
                {
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    }
                };
                break;
            case Upgrade.A:
                result = new()
                {
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    }
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 2,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 2,
                        targetPlayer = true
                    },
                    new AMove()
                    {
                        dir = 3,
                        isRandom = true,
                        targetPlayer = true
                    }
                };
                break;
        }
        return result;
    }
}
