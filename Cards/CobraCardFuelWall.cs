using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardFuelWall : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("FuelWall", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = Deck.colorless,
                rarity = Rarity.rare,
                upgradesTo = [Upgrade.A, Upgrade.B],
                dontOffer = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "FuelWall", "name"]).Localize
        });
    }
    public override string Name() => "Adv. Heat Protection";
    public override CardData GetData(State state)
    {
        return new CardData()
        {
            art = ModEntry.Instance.Sprites["CorrosionBlockStarter"].Sprite,
            artTint = "45e0ab",
            cost = upgrade == Upgrade.A ? 0 : 1
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var result = new List<CardAction>();
        switch (upgrade)
        {
            case Upgrade.None:
                result = new() {
                    new AStatus()
                    {
                        status = Status.shield,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    },
                    new ADrawCard()
                    {
                        count = 1,
                    }
                };
                break;
            case Upgrade.A:
                result = new() {
                    new AStatus()
                    {
                        status = Status.shield,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    },
                    new ADrawCard()
                    {
                        count = 1,
                    }
                };
                break;
            case Upgrade.B:
                result = new() {
                    new AStatus()
                    {
                        status = Status.shield,
                        statusAmount = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    },
                    new ADrawCard()
                    {
                        count = 2,
                    }
                };
                break;
        }
        return result;
    }

};
