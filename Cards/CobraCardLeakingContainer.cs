using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardLeakingContainer : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("LeakingContainer", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.CobraDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "LeakingContainer", "name"]).Localize
        });
    }
    public override string Name() => "Leaking Container";
    public override CardData GetData(State state)
    {
        Spr? artSpr;
        switch (upgrade)
        {
            case Upgrade.B:
                artSpr = !flipped ? ModEntry.Instance.Sprites["Split3_2TopSprite"].Sprite : ModEntry.Instance.Sprites["Split3_2BottomSprite"].Sprite;
                break;
            default:
                artSpr = !flipped ? ModEntry.Instance.Sprites["SplitHalfTopSprite"].Sprite : ModEntry.Instance.Sprites["SplitHalfBottomSprite"].Sprite;
                break;
        }
        return new CardData()
        {
            floppable = true,
            retain = true,
            cost = upgrade == Upgrade.A ? 1 : 2,
            art = artSpr
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
                    new AHurt()
                    {
                        hurtAmount = 3,
                        targetPlayer = true,
                        dialogueSelector = ".LeakingContainer",
                        disabled = flipped
                    },
                    new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = 4,
                        targetPlayer = false,
                        disabled = flipped
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 3),
                        disabled = !flipped
                    },
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true,
                        disabled = !flipped
                    }
                };
                break;
            case Upgrade.A:
                result = new()
                {
                    new AHurt()
                    {
                        hurtAmount = 1,
                        targetPlayer = true,
                        dialogueSelector = ".LeakingContainer",
                        disabled = flipped
                    },
                    new AStatus()
                    {
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 7,
                        targetPlayer = false,
                        disabled = flipped
                    },
                    new AHurt()
                    {
                        hurtAmount = 1,
                        targetPlayer = true,
                        disabled = !flipped
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 4),
                        disabled = !flipped
                    }
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 10,
                        targetPlayer = true,
                        dialogueSelector = ".LeakingContainer",
                        disabled = flipped
                    },
                    new AStunShip()
                    {
                        disabled = flipped
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 2),
                        disabled = !flipped
                    }
                };
                break;
        }
        return result;
    }
}
